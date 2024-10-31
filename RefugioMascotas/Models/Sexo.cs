using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RefugioMascotas.Models
{
    public class Sexo
    {
        [Key]
        public int IdSexo { get; set; } 
        public string? TipoSexo { get; set; } = null!;
        
        public virtual List<Empleado>? Empleado { get; set; } = new List<Empleado>();
        [JsonIgnore]
        public virtual List<Adoptante>? adoptantes { get; set; }
       
        public virtual List<Mascota>? Mascotas { get; set; }
        
    }
}
