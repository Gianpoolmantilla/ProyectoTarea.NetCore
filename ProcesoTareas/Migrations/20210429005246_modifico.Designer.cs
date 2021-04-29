﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProcesoTareas.Models;

namespace ProcesoTareas.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20210429005246_modifico")]
    partial class modifico
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProcesoTareas.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CodEstado")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estados");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CodEstado = 0,
                            Descripcion = "Alta"
                        },
                        new
                        {
                            Id = 2,
                            CodEstado = 50,
                            Descripcion = "Modificacion"
                        },
                        new
                        {
                            Id = 3,
                            CodEstado = 100,
                            Descripcion = "Pendiente"
                        },
                        new
                        {
                            Id = 4,
                            CodEstado = 600,
                            Descripcion = "Realizado"
                        },
                        new
                        {
                            Id = 5,
                            CodEstado = 900,
                            Descripcion = "Rechazado"
                        });
                });

            modelBuilder.Entity("ProcesoTareas.Models.Prioridad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Debaja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaMod")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prioridades");
                });

            modelBuilder.Entity("ProcesoTareas.Models.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Debaja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaMod")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrioridadId")
                        .HasColumnType("int");

                    b.Property<int>("TipoTareaId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("PrioridadId");

                    b.HasIndex("TipoTareaId");

                    b.ToTable("Tarea");
                });

            modelBuilder.Entity("ProcesoTareas.Models.TipoTarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Debaja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaMod")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoTareas");
                });

            modelBuilder.Entity("ProcesoTareas.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Debaja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaMod")
                        .HasColumnType("datetime2");

                    b.Property<string>("LoginErrorMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreuserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Debaja = "",
                            Email = "soporte@mail.com",
                            FechaAlta = new DateTime(2021, 4, 28, 21, 52, 45, 944, DateTimeKind.Local).AddTicks(6029),
                            FechaMod = new DateTime(2021, 4, 28, 21, 52, 45, 946, DateTimeKind.Local).AddTicks(8926),
                            Nombre = "Administrador",
                            NombreuserId = "admin",
                            Password = "123",
                            UserId = ""
                        });
                });

            modelBuilder.Entity("ProcesoTareas.Models.Tarea", b =>
                {
                    b.HasOne("ProcesoTareas.Models.Estado", "Estado")
                        .WithMany("Tarea")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProcesoTareas.Models.Prioridad", "Prioridad")
                        .WithMany("Tarea")
                        .HasForeignKey("PrioridadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProcesoTareas.Models.TipoTarea", "TipoTarea")
                        .WithMany("Tarea")
                        .HasForeignKey("TipoTareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("Prioridad");

                    b.Navigation("TipoTarea");
                });

            modelBuilder.Entity("ProcesoTareas.Models.Estado", b =>
                {
                    b.Navigation("Tarea");
                });

            modelBuilder.Entity("ProcesoTareas.Models.Prioridad", b =>
                {
                    b.Navigation("Tarea");
                });

            modelBuilder.Entity("ProcesoTareas.Models.TipoTarea", b =>
                {
                    b.Navigation("Tarea");
                });
#pragma warning restore 612, 618
        }
    }
}