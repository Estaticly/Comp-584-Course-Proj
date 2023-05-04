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
        public async Task<ActionResult<NewShoe>> PostShoe(NewShoe newShoe)
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

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Shoe>>> GetShoes()
        {
            if (_context.Brands == null)
            {
                return NotFound();
            }
            return await _context.Shoes.ToListAsync();
        }
    }
}
