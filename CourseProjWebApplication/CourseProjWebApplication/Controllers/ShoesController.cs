using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeExplorerModel;
using CourseProjWebApplication.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace CourseProjWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
        private readonly ShoeExplorerContext _context;

        public ShoesController(ShoeExplorerContext context)
        {
            _context = context;
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<NewShoe>> PostShoe(NewShoe newShoe)//adds a new shoe
        {
            Dictionary<string, Brand> brands= await _context.Brands
                .AsNoTracking().ToDictionaryAsync(b => b.BrandName);

            if (!brands.ContainsKey(newShoe.Brand))
            {
                return NotFound(newShoe.Brand);
            }
            if(string.IsNullOrEmpty(newShoe.Brand)||string.IsNullOrEmpty(newShoe.Model))
            {
                return Problem("Brand/Model is empty");
            }

            Shoe shoe = new()
            {
                Brand = newShoe.Brand,
                Model = newShoe.Model,
                Size = newShoe.Size,
                Price = newShoe.Price,

                BrandId = brands[newShoe.Brand].Id,
            };
            Brand b = brands[newShoe.Brand];
            b.ShoeCount++;

            _context.Shoes.Add(shoe);
            _context.Brands.Attach(b).Property(t => t.ShoeCount).IsModified = true;
                
            await _context.SaveChangesAsync();
            return newShoe;
        }

        //Gets all shoes by the brand
        [HttpGet("ShoeByBrand/{id}")]
        public async Task<ActionResult<IEnumerable<NewShoe>>> GetShoeByBrand(int id)
        {   Brand? brand= await _context.Brands.FindAsync(id);
            if (brand is null)
            {
                return NotFound();
            }
            List<Shoe> shoes = await _context.Shoes.ToListAsync();
            if(shoes.Count == 0)
            {
                Console.WriteLine("No shoes in DB");
            }
            List<NewShoe> shoesByBrand = new List<NewShoe>();
            foreach (Shoe shoe in shoes)
            {
                if (shoe.BrandId == id)
                {
                    NewShoe s = new()
                    {
                        //Id = shoe.Id,
                        Brand = shoe.Brand,
                        Model = shoe.Model,
                        Size = shoe.Size,
                        Price = shoe.Price,
                    };
                    shoesByBrand.Add(s);
                }
            }
            return shoesByBrand;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Shoe>>> GetShoes()//Gets all shoes
        {
            if (_context.Brands == null)
            {
                return NotFound();
            }
            return await _context.Shoes.ToListAsync();
        }
    }
}
