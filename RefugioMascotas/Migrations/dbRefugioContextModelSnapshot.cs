﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RefugioMascotas.dbContext;

#nullable disable

namespace RefugioMascotas.Migrations
{
    [DbContext(typeof(dbRefugioContext))]
    partial class dbRefugioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("RefugioMascotas.Models.Adopcion", b =>
                {
                    b.Property<int>("IdAdopcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdAdopcion"));

                    b.Property<DateOnly>("FechaAdopcion")
                        .HasColumnType("date");

                    b.Property<int>("IdAdoptante")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdMascota")
                        .HasColumnType("int");

                    b.HasKey("IdAdopcion");

                    b.HasIndex("IdAdoptante");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("IdMascota");

                    b.ToTable("adopcions");
                });

            modelBuilder.Entity("RefugioMascotas.Models.Adoptante", b =>
                {
                    b.Property<int>("IdAdoptante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdAdoptante"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("IdSexo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdAdoptante");

                    b.HasIndex("IdSexo");

                    b.ToTable("adoptantes");
                });

            modelBuilder.Entity("RefugioMascotas.Models.CuidadoMedico", b =>
                {
                    b.Property<int>("IdCuidadoMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdCuidadoMedico"));

                    b.Property<string>("EstadoSalud")
                        .HasColumnType("longtext");

                    b.Property<int>("MascotaIdMascota")
                        .HasColumnType("int");

                    b.Property<string>("Tratamiento")
                        .HasColumnType("longtext");

                    b.HasKey("IdCuidadoMedico");

                    b.HasIndex("MascotaIdMascota");

                    b.ToTable("cuidadoMedicos");
                });

            modelBuilder.Entity("RefugioMascotas.Models.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdEmpleado"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdSexo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .HasColumnType("longtext");

                    b.HasKey("IdEmpleado");

                    b.HasIndex("IdSexo");

                    b.ToTable("empleados");
                });

            modelBuilder.Entity("RefugioMascotas.Models.EstadoAdopcion", b =>
                {
                    b.Property<int>("IdEstadoAdopcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdEstadoAdopcion"));

                    b.Property<string>("EstadodeAdopcion")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdEstadoAdopcion");

                    b.ToTable("EstadoAdopcions");
                });

            modelBuilder.Entity("RefugioMascotas.Models.Mascota", b =>
                {
                    b.Property<int>("IdMascota")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdMascota"));

                    b.Property<string>("Edad")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("FechaIngreso")
                        .HasColumnType("date");

                    b.Property<string>("FotoMascota")
                        .HasColumnType("longtext");

                    b.Property<int>("IdEstadoAdopcion")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoMascota")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("SexoMascota")
                        .HasColumnType("int");

                    b.HasKey("IdMascota");

                    b.HasIndex("IdEstadoAdopcion");

                    b.HasIndex("IdTipoMascota");

                    b.HasIndex("SexoMascota");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("RefugioMascotas.Models.Sexo", b =>
                {
                    b.Property<int>("IdSexo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdSexo"));

                    b.Property<string>("TipoSexo")
                        .HasColumnType("longtext");

                    b.HasKey("IdSexo");

                    b.ToTable("sexo");
                });

            modelBuilder.Entity("RefugioMascotas.Models.TipoMascota", b =>
                {
                    b.Property<int>("IdTipoMascota")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdTipoMascota"));

                    b.Property<string>("Especie")
                        .HasColumnType("longtext");

                    b.Property<string>("Raza")
                        .HasColumnType("longtext");

                    b.HasKey("IdTipoMascota");

                    b.ToTable("TipoMascotas");
                });

            modelBuilder.Entity("RefugioMascotas.Models.Adopcion", b =>
                {
                    b.HasOne("RefugioMascotas.Models.Adoptante", "AdoptanteNavigation")
                        .WithMany("Adopciones")
                        .HasForeignKey("IdAdoptante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RefugioMascotas.Models.Empleado", "EmpleadoNavigation")
                        .WithMany("Adopciones")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RefugioMascotas.Models.Mascota", "MascotaNavigation")
                        .WithMany("Adopciones")
                        .HasForeignKey("IdMascota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdoptanteNavigation");

                    b.Navigation("EmpleadoNavigation");

                    b.Navigation("MascotaNavigation");
                });

            modelBuilder.Entity("RefugioMascotas.Models.Adoptante", b =>
                {
                    b.HasOne("RefugioMascotas.Models.Sexo", "SexoNavigation")
                        .WithMany("adoptantes")
                        .HasForeignKey("IdSexo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SexoNavigation");
                });

            modelBuilder.Entity("RefugioMascotas.Models.CuidadoMedico", b =>
                {
                    b.HasOne("RefugioMascotas.Models.Mascota", "Mascota")
                        .WithMany("CuidadoMedicos")
                        .HasForeignKey("MascotaIdMascota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("RefugioMascotas.Models.Empleado", b =>
                {
                    b.HasOne("RefugioMascotas.Models.Sexo", "SexoNavigation")
                        .WithMany("Empleado")
                        .HasForeignKey("IdSexo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SexoNavigation");
                });

            modelBuilder.Entity("RefugioMascotas.Models.Mascota", b =>
                {
                    b.HasOne("RefugioMascotas.Models.EstadoAdopcion", "EstadoAdopcionNavigation")
                        .WithMany("Mascotas")
                        .HasForeignKey("IdEstadoAdopcion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RefugioMascotas.Models.TipoMascota", "TipoMascotaNavigation")
                        .WithMany("Mascotas")
                        .HasForeignKey("IdTipoMascota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RefugioMascotas.Models.Sexo", "SexoNavigation")
                        .WithMany("Mascotas")
                        .HasForeignKey("SexoMascota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoAdopcionNavigation");

                    b.Navigation("SexoNavigation");

                    b.Navigation("TipoMascotaNavigation");
                });

            modelBuilder.Entity("RefugioMascotas.Models.Adoptante", b =>
                {
                    b.Navigation("Adopciones");
                });

            modelBuilder.Entity("RefugioMascotas.Models.Empleado", b =>
                {
                    b.Navigation("Adopciones");
                });

            modelBuilder.Entity("RefugioMascotas.Models.EstadoAdopcion", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("RefugioMascotas.Models.Mascota", b =>
                {
                    b.Navigation("Adopciones");

                    b.Navigation("CuidadoMedicos");
                });

            modelBuilder.Entity("RefugioMascotas.Models.Sexo", b =>
                {
                    b.Navigation("Empleado");

                    b.Navigation("Mascotas");

                    b.Navigation("adoptantes");
                });

            modelBuilder.Entity("RefugioMascotas.Models.TipoMascota", b =>
                {
                    b.Navigation("Mascotas");
                });
#pragma warning restore 612, 618
        }
    }
}
