using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeExplorerModel;

namespace CourseProjWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ShoeExplorerContext _context;

        public BrandsController(ShoeExplorerContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            if (_context.Brands == null)
            {
                return NotFound();
            }
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return brand;
        }


        //Post: api/Seed
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {
            if (_context.Brands == null)
            {
                return Problem("enitiy set 'ShoeExplorerContext.Brands' is null.");
            }

            Dictionary<string, Brand> brandsByName = await _context.Brands
                .AsNoTracking().ToDictionaryAsync(b => b.BrandName);

            if (brandsByName.ContainsKey(brand.BrandName))
            {
                return Problem("Entry already in Database");
            }
            else
            {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
            }

            
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            if(_context.Brands == null)
            {
                return NotFound();
            }
            return await _context.Brands.ToListAsync();
        }
    }
}
