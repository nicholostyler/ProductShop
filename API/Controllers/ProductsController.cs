using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // Inject the efcore database context using DI.
        // Only available for the HTTP request, and released from memory.
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet] //ex: api/Products
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            // Use the efcore database context to call the Products table toList using linq.
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")] //ex: api/Products/8
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}