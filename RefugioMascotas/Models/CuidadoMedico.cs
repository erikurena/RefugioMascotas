using System.ComponentModel.DataAnnotations;

namespace RefugioMascotas.Models
{
    public class CuidadoMedico
    {
        [Key]
        public int IdCuidadoMedico { get; set; }
        public string? EstadoSalud { get; set; }
        public string? Tratamiento { get; set; }
       public virtual Mascota Mascota { get; set; }
    }
}
