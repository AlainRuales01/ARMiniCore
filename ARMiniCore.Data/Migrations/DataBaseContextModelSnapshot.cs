﻿// <auto-generated />
using System;
using ARMiniCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ARMiniCore.Data.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ARMiniCore.Data.Models.Pase", b =>
                {
                    b.Property<int>("PaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaseId"), 1L, 1);

                    b.Property<double>("Costo")
                        .HasColumnType("float");

                    b.Property<double>("CostoPase")
                        .HasColumnType("float");

                    b.Property<int>("Pases")
                        .HasColumnType("int");

                    b.Property<string>("TipoPase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaseId");

                    b.ToTable("Pase", (string)null);
                });

            modelBuilder.Entity("ARMiniCore.Data.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"), 1L, 1);

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("ARMiniCore.Data.Models.UsuarioPase", b =>
                {
                    b.Property<int>("UsuarioPaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioPaseId"), 1L, 1);

                    b.Property<int>("PaseId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaExpiracion")
                        .HasColumnType("datetime2");

                    b.HasKey("UsuarioPaseId");

                    b.HasIndex("PaseId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioPase", (string)null);
                });

            modelBuilder.Entity("ARMiniCore.Data.Models.UsuarioPase", b =>
                {
                    b.HasOne("ARMiniCore.Data.Models.Pase", "Pase")
                        .WithMany("UsuarioPases")
                        .HasForeignKey("PaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARMiniCore.Data.Models.Usuario", "Usuario")
                        .WithMany("UsuarioPases")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pase");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ARMiniCore.Data.Models.Pase", b =>
                {
                    b.Navigation("UsuarioPases");
                });

            modelBuilder.Entity("ARMiniCore.Data.Models.Usuario", b =>
                {
                    b.Navigation("UsuarioPases");
                });
#pragma warning restore 612, 618
        }
    }
}
