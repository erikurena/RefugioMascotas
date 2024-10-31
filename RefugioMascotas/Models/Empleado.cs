using System.ComponentModel.DataAnnotations;

namespace RefugioMascotas.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        [Required]
        [MaxLength(50)]
        public string  Nombre { get; set; }
        [Required]
        [MaxLength(60)]
        public string  Apellido { get; set; }
        public int IdSexo { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Cargo { get; set; }
        public string? Telefono { get; set; }
        public virtual Sexo? SexoNavigation { get; set; }
        public virtual List<Adopcion>? Adopciones { get; set; }
    }
}
