using Microsoft.AspNetCore.Mvc;
using VeterinariaAPI.AppDbContext;
using VeterinariaAPI.Models;
using VeterinariaAPI.DTOs;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaAPI.Controllers
{
    [ApiController]
    [Route("api/atencion")]
    public class AtencionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AtencionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{IdAtencion}")]
        public ActionResult GetAtencion(int IdAtencion)
        {
            var atencion = _context.Atenciones
                .Include(x => x.Animal)
                .SingleOrDefault(x => x.Id == IdAtencion);

            if (atencion == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(atencion);
            }
        }

        [HttpGet(Name = "GetAtencion")]
        public List<Atencion> GetAtenciones()
        {
            return _context.Atenciones.Include(x => x.Animal).ToList();
        }
        

        [HttpPost(Name = "CreateAtencion")]
        public ActionResult CreateAtencion(AtencionPostDto atencionDto)
        {
            int dias = (DateTime.Now - atencionDto.Fecha).Days;
            if (dias > 30 )
            {
                return BadRequest();
            }
            var animal = _context.Animales.Find(atencionDto.AnimalId);

            if(animal == null)
            {
                return NotFound();
            }

            var atencion = new Atencion
            {
                Fecha = atencionDto.Fecha,
                Motivo = atencionDto.Motivo,
                Tratamiento = atencionDto.Tratamiento,
                Medicamentos = atencionDto.Medicamentos,
                Animal = animal,
            };

            _context.Atenciones.Add(atencion);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{IdAtencion}")]
        public ActionResult DeleteAtencion(int IdAtencion)
        {
            var atencion = _context.Atenciones.Find(IdAtencion);
            if (atencion == null)
            {
                return NotFound();
            }
            else
            {
                _context.Atenciones.Remove(atencion);
                _context.SaveChanges();
                return Ok();
            }
        }
        [HttpGet("med/{IdAtencion}")]
        public ActionResult GetMedicamentos(int IdAtencion)
        {
            var atencion = _context.Atenciones.Find(IdAtencion);

            if(atencion == null)
            {
                return NotFound();
            }

            List<string> medicamentos = ((Atencion)atencion).Medicamentos;

            return Ok(medicamentos);
        }
    }
}
