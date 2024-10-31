using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace RefugioMascotas.Models
{
    public class Mascota
    {
        [Key]
        public int IdMascota { get; set; }
        [MaxLength(50)]
        public string? Nombre { get; set; }
        public string? Edad { get; set; }
        public int SexoMascota { get; set; }
        public int IdTipoMascota { get; set; }
        public DateOnly? FechaIngreso { get; set; }
        public int IdEstadoAdopcion { get; set; }
        public string? FotoMascota { get; set; } 
        [NotMapped]
        [Display(Name = "Cargar Foto")]
        public IFormFile? FotoFileMascota { get; set; }
      
        public virtual TipoMascota? TipoMascotaNavigation { get; set; } 
        public virtual Sexo? SexoNavigation { get; set; }
        [JsonIgnore]
        public virtual List<Adopcion>? Adopciones { get; set; }
        [JsonIgnore]
        public virtual List<CuidadoMedico>? CuidadoMedicos { get; set; }

        public virtual EstadoAdopcion? EstadoAdopcionNavigation { get; set; }

    }
}
