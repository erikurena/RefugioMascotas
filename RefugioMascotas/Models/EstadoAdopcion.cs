using System.ComponentModel.DataAnnotations;

namespace RefugioMascotas.Models
{
    public class EstadoAdopcion
    {
        [Key]
        public int IdEstadoAdopcion { get; set; }
        [MaxLength(50)]
        public string? EstadodeAdopcion { get; set; }

        public virtual List<Mascota>? Mascotas {  get; set; } 
    }
}
