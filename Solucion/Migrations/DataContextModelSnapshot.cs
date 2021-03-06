﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solucion.Data;

namespace Solucion.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Solucion.Model.Balance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaBalance");

                    b.Property<int>("TarjetaId");

                    b.HasKey("Id");

                    b.HasIndex("TarjetaId");

                    b.ToTable("Balance");
                });

            modelBuilder.Entity("Solucion.Model.Retiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaRetiro");

                    b.Property<double>("Monto");

                    b.Property<int>("TarjetaId");

                    b.HasKey("Id");

                    b.HasIndex("TarjetaId");

                    b.ToTable("Retiro");
                });

            modelBuilder.Entity("Solucion.Model.Tarjeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Bloqueada");

                    b.Property<DateTime>("FechaVencimiento");

                    b.Property<double>("Monto");

                    b.Property<long>("Numero");

                    b.Property<int>("Pin");

                    b.HasKey("Id");

                    b.ToTable("Tarjeta");
                });

            modelBuilder.Entity("Solucion.Model.Balance", b =>
                {
                    b.HasOne("Solucion.Model.Tarjeta", "Tarjeta")
                        .WithMany()
                        .HasForeignKey("TarjetaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Solucion.Model.Retiro", b =>
                {
                    b.HasOne("Solucion.Model.Tarjeta", "Tarjeta")
                        .WithMany()
                        .HasForeignKey("TarjetaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
