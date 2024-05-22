using VeterinariaAPI.Models;

namespace VeterinariaAPI.DTOs
{
    public class AnimalPostDto
    {
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public int DuenioId { get; set; }
    }
}
