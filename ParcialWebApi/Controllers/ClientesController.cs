using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialWebApi.Data;
using ParcialWebApi.Interfaces;
using ParcialWebApi.Models;

namespace ParcialWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ClientesController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IFechaService _fechaService;

        public ClientesController(
            AppDbContext context,
            ILogger<ClientesController> logger,
            IConfiguration configuration,
            IFechaService fechaService)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
            _fechaService = fechaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation(
                "Listado de clientes solicitado a las {fecha}",
                _fechaService.ObtenerFechaActual()
            );

            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return Ok(cliente);
        }
    }
}
