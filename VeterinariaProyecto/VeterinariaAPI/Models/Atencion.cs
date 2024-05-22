namespace VeterinariaAPI.Models
{
    public class Atencion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public string Tratamiento { get; set; }
        public List<string> Medicamentos { get; set; }
        public Animal Animal { get; set; }
    }
}
