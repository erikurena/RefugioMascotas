using System.ComponentModel.DataAnnotations;

namespace RefugioMascotas.Models
{
    public class Adopcion
    {
        [Key]
        public int IdAdopcion { get; set; }
        public DateOnly FechaAdopcion { get; set; }
       public int IdMascota { get; set; }
        public int IdAdoptante { get; set; }
        public int IdEmpleado { get; set; }
        public virtual Mascota? MascotaNavigation { get; set; }
        public virtual Adoptante? AdoptanteNavigation { get; set; }
        public virtual Empleado? EmpleadoNavigation { get; set; }  

    }
}
