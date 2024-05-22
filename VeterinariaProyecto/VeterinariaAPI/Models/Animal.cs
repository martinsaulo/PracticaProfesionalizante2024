namespace VeterinariaAPI.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public Cliente Duenio { get; set; }
    }
}
