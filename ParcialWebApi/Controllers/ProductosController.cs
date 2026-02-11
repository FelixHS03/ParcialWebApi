using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialWebApi.Data;
using ParcialWebApi.Models;

namespace ParcialWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProductosController> _logger;

        public ProductosController(AppDbContext context, ILogger<ProductosController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Listado de productos solicitado");
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<IActionResult> Post(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Producto creado con Id {id}", producto.Id);

            return Ok(producto);
        }
    }
}
