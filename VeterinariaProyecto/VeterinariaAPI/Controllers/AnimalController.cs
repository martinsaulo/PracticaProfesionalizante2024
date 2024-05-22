using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.AppDbContext;
using VeterinariaAPI.DTOs;
using VeterinariaAPI.Models;

namespace VeterinariaAPI.Controllers
{
    [ApiController]
    [Route("api/animal")]
    public class AnimalController : ControllerBase
    {
        private readonly ApplicationDbContext _context; //ver para cambiar

        public AnimalController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "GetAnimal")]
        public List<Animal> GetAnimales()
        {
            return _context.Animales.ToList();
        }
        [HttpGet("{IdAnimal}")]
        public ActionResult GetAnimal(int IdAnimal)
        {
            var animal = _context.Animales
                .Include(x => x.Duenio)
                .FirstOrDefault(x => x.Id == IdAnimal);
            
            if (animal == null)
            {
                return NotFound();
                
            }
            else
            {
                AnimalGetDto animalDto = new AnimalGetDto
                {
                    IdAnimal = animal.Id,
                    Nombre = animal.Nombre,
                    Raza = animal.Raza,
                    Sexo = animal.Sexo,
                    Edad = animal.Edad,
                    Duenio = animal.Duenio
                };
                return Ok(animalDto);
            }
        }

        [HttpPost(Name = "CreateAnimal")]
        public ActionResult CreateAnimal(AnimalPostDto animalDto)
        {
            var duenio = _context.Clientes.Find(animalDto.DuenioId);

            if (duenio == null)
            {
                return NotFound();
            }

            var animal = new Animal
            {
                Nombre = animalDto.Nombre,
                Raza = animalDto.Raza,
                Edad = animalDto.Edad,
                Duenio = duenio,
                Sexo = animalDto.Sexo,
            };

            _context.Animales.Add(animal);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{IdAnimal}")]
        public ActionResult EditAnimal(int IdAnimal, AnimalPostDto animalDto)
        {
            var animal = _context.Animales.Find(IdAnimal);

            if(animal == null)
            {
                return NotFound();
            }

            var duenio = _context.Clientes.Find(animalDto.DuenioId);

            if(duenio == null)
            {
                return NotFound();
            }
            animal.Nombre = animalDto.Nombre;
            animal.Edad = animalDto.Edad;
            animal.Raza = animalDto.Raza;
            animal.Sexo = animalDto.Sexo;
            animal.Duenio = duenio;

            _context.Animales.Update(animal);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{IdAnimal}")]
        public ActionResult DeleteAnimal(int IdAnimal)
        {
            var animal = _context.Animales.Find(IdAnimal);
            if (animal == null)
            {
                return NotFound();
            }
            else
            {
                var atencionesAnimales = _context.Atenciones.Where(x => x.Animal.Id == animal.Id);

                _context.Atenciones.RemoveRange(atencionesAnimales);
                _context.Animales.Remove(animal);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
