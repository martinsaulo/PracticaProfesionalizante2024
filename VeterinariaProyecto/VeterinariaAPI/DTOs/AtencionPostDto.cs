using VeterinariaAPI.Models;

namespace VeterinariaAPI.DTOs
{
    public class AtencionPostDto
    {
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public string Tratamiento { get; set; }
        public List<string> Medicamentos { get; set; }
        public int AnimalId { get; set; }
    }
}
