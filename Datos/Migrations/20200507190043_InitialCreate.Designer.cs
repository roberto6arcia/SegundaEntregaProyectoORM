﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(ProductosContext))]
    [Migration("20200507190043_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Producto", b =>
                {
                    b.Property<string>("CodigoP")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CantidadP")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fechadevencimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("LaboratorioP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoP");

                    b.ToTable("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
