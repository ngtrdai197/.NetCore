using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreUsingVsCode.DTO;
using NetCoreUsingVsCode.Models;

namespace NetCoreUsingVsCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var products = await db.Products.ToListAsync();
                var productsMapper = _mapper.Map<IEnumerable<ProductDTO>>(products);
                return Ok(productsMapper);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    var product = await db.Products.FindAsync(id);
                    if (product == null) return NotFound();
                    var productMapper = _mapper.Map<ProductDTO>(product);
                    return Ok(productMapper);
                }
                catch (System.Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
    }
}