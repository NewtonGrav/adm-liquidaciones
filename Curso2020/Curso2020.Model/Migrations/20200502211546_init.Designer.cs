﻿// <auto-generated />
using System;
using Curso.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Curso2020.Model.Migrations
{
    [DbContext(typeof(CursoContext))]
    [Migration("20200502211546_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Curso2020.Model.Model.ArchivoEmpleados", b =>
                {
                    b.Property<string>("archivo")
                        .HasColumnName("nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("fechaDeProcesado")
                        .HasColumnType("datetime2");

                    b.HasKey("archivo");

                    b.ToTable("ArchivosEmpleados");
                });

            modelBuilder.Entity("Curso2020.Model.Model.Autorizacion", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cuitEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("fecha")
                        .IsRequired()
                        .HasColumnType("nvarchar(7)")
                        .HasMaxLength(7);

                    b.HasKey("id");

                    b.ToTable("Autorizaciones");
                });

            modelBuilder.Entity("Curso2020.Model.Model.Empleado", b =>
                {
                    b.Property<string>("dni")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("archivo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cuitEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("horasTrabajadasUltimoMes")
                        .HasColumnType("int");

                    b.Property<int>("idPuesto")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("dni");

                    b.HasIndex("archivo");

                    b.HasIndex("cuitEmpresa");

                    b.HasIndex("idPuesto");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Curso2020.Model.Model.Empresa", b =>
                {
                    b.Property<string>("cuit")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("razonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("cuit");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Curso2020.Model.Model.Liquidacion", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cuitEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("dniEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("fecha")
                        .IsRequired()
                        .HasColumnType("nvarchar(7)")
                        .HasMaxLength(7);

                    b.Property<double>("liquidacion")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Liquidaciones");
                });

            modelBuilder.Entity("Curso2020.Model.Model.Puesto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("salarioPorDefecto")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Puestos");
                });

            modelBuilder.Entity("Curso2020.Model.Model.PuestoEmpresa", b =>
                {
                    b.Property<int>("puestoId")
                        .HasColumnType("int");

                    b.Property<string>("empresaCuit")
                        .HasColumnType("nvarchar(11)");

                    b.Property<double>("pagoPorHora")
                        .HasColumnType("float");

                    b.HasKey("puestoId", "empresaCuit");

                    b.HasIndex("empresaCuit");

                    b.ToTable("PuestosEmpresa");
                });

            modelBuilder.Entity("Curso2020.Model.Model.Empleado", b =>
                {
                    b.HasOne("Curso2020.Model.Model.ArchivoEmpleados", "archivosEmpleados")
                        .WithMany()
                        .HasForeignKey("archivo");

                    b.HasOne("Curso2020.Model.Model.Empresa", "empresa")
                        .WithMany()
                        .HasForeignKey("cuitEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Curso2020.Model.Model.Puesto", "puestosEmpresas")
                        .WithMany()
                        .HasForeignKey("idPuesto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Curso2020.Model.Model.PuestoEmpresa", b =>
                {
                    b.HasOne("Curso2020.Model.Model.Empresa", "empresa")
                        .WithMany("Puestos")
                        .HasForeignKey("empresaCuit")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Curso2020.Model.Model.Puesto", "puesto")
                        .WithMany("Empresas")
                        .HasForeignKey("puestoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
