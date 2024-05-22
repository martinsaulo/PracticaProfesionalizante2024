using Microsoft.AspNetCore.Mvc;
using VeterinariaAPI.AppDbContext;
using VeterinariaAPI.DTOs;
using VeterinariaAPI.Models;

namespace VeterinariaAPI.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context; //ver para cambiar

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("{IdCliente}")]
        public ActionResult GetCliente(int IdCliente)
        {
            var cliente = _context.Clientes.Find(IdCliente);

            if (cliente == null)
            {
                return NotFound();
            }
            else
            {   
                return Ok(cliente);
            }
        }

        [HttpGet(Name = "GetClientes")]
        public List<Cliente> GetClientes()
        {
            return _context.Clientes.ToList();
        }

        [HttpPost(Name = "CreateCliente")]
        public ActionResult CreateCliente(ClientePostDto clienteDto)
        {
            var cliente = new Cliente
            {
                Nombre = clienteDto.Nombre,
                Apellido = clienteDto.Apellido,
                DNI = clienteDto.DNI
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{IdCliente}")]
        public ActionResult DeleteCliente(int IdCliente)
        {
            var cliente = _context.Clientes.Find(IdCliente);
            if (cliente == null)
            {
                return NotFound();
            }
            else
            {
                var animalesCliente = _context.Animales.Where(x => x.Duenio.Id == cliente.Id);
                _context.Animales.RemoveRange(animalesCliente);
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                return Ok();
            }

        }
    }
}
