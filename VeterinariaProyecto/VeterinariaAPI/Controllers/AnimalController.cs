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
        private readonly ApplicationDbContext _context;

        public AnimalController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "GetAnimal")]
        public List<AnimalGetDto> GetAnimales()
        {
            var animales = _context.Animales.Include(x => x.Duenio).ToList();
            List<AnimalGetDto> animalesDto = new List<AnimalGetDto>();
            foreach (var a in animales)
            {
                var animalDto = new AnimalGetDto
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    Raza = a.Raza,
                    Sexo = a.Sexo,
                    Edad = a.Edad,
                };
                if(a.Duenio == null)
                {
                    animalDto.Duenio = "Sin datos";
                }
                else
                {
                    animalDto.Duenio = a.Duenio.Nombre + " " + a.Duenio.Apellido;
                }

                animalesDto.Add(animalDto);
            }

            return animalesDto;
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
                    Id = animal.Id,
                    Nombre = animal.Nombre,
                    Raza = animal.Raza,
                    Sexo = animal.Sexo,
                    Edad = animal.Edad,
                    Duenio = animal.Duenio.Nombre + " " + animal.Duenio.Apellido,
                    DuenioId = animal.Duenio.Id
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
