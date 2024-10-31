using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RefugioMascotas.Models
{
    public class TipoMascota
    {
        [Key]
        public int IdTipoMascota { get; set; }
        public string? Especie { get; set; }
        public string? Raza { get; set; }
        
        public virtual List<Mascota>? Mascotas { get; set; } 
    }
}
