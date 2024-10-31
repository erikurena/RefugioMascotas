using System.ComponentModel.DataAnnotations;

namespace RefugioMascotas.Models
{
    public class Adoptante
    {
        [Key]
        public int IdAdoptante { get; set; }
        [Required]
        [StringLength(60)]
        public string Nombre {  get; set; }
        [Required]
        [MaxLength(60)]
        public string Apellido { get; set; }
        public int IdSexo { get; set; }
        [Required]
        [MaxLength(200)]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        public virtual Sexo? SexoNavigation { get; set; }

        public virtual ICollection<Adopcion>? Adopciones { get; set; }
    }
}
