using Microsoft.EntityFrameworkCore;
using RefugioMascotas.Models;
using System.Data;

namespace RefugioMascotas.dbContext
{
    public class dbRefugioContext :DbContext
    {
        public dbRefugioContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<TipoMascota> TipoMascotas { get; set; }
        public DbSet<Adopcion> adopcions { get; set; }
        public DbSet<Adoptante> adoptantes { get; set; }
        public DbSet<CuidadoMedico> cuidadoMedicos { get; set; }
        public DbSet<Empleado> empleados { get; set; }
        public DbSet<Sexo> sexo { get; set; }
        public DbSet<EstadoAdopcion> EstadoAdopcions {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura la relación uno a muchos
            modelBuilder.Entity<Sexo>()
                .HasMany(s => s.Mascotas)
                .WithOne(m => m.SexoNavigation)
                .HasForeignKey(m => m.SexoMascota);

            modelBuilder.Entity<TipoMascota>()
                .HasMany(t => t.Mascotas)
                .WithOne(m => m.TipoMascotaNavigation)
                .HasForeignKey(m => m.IdTipoMascota);

            modelBuilder.Entity<Sexo>()
                .HasMany(x => x.Empleado)
                .WithOne(m => m.SexoNavigation)
                .HasForeignKey(m => m.IdSexo);

            modelBuilder.Entity<Sexo>()
               .HasMany(x => x.adoptantes)
               .WithOne(m => m.SexoNavigation)
               .HasForeignKey(m => m.IdSexo);

            modelBuilder.Entity<Adoptante>()
                .HasMany(a => a.Adopciones)
                .WithOne(x => x.AdoptanteNavigation)
                .HasForeignKey(x => x.IdAdoptante);

            modelBuilder.Entity<Mascota>()
                .HasMany(m => m.Adopciones)
                .WithOne( x => x.MascotaNavigation)
                .HasForeignKey(x => x.IdMascota);

            modelBuilder.Entity<Empleado>()
                .HasMany(m => m.Adopciones)
                .WithOne(x => x.EmpleadoNavigation)
                .HasForeignKey(x => x.IdEmpleado);

            modelBuilder.Entity<EstadoAdopcion>()
                .HasMany(e => e.Mascotas)
                .WithOne(x => x.EstadoAdopcionNavigation)
                .HasForeignKey(x => x.IdEstadoAdopcion);
        }

    }
}
