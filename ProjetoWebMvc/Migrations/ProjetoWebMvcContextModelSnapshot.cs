﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoWebMvc.Data;

namespace ProjetoWebMvc.Migrations
{
    [DbContext(typeof(ProjetoWebMvcContext))]
    partial class ProjetoWebMvcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjetoWebMvc.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("ProjetoWebMvc.Models.SalesRecord", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("Sellerid");

                    b.Property<int>("Status");

                    b.HasKey("id");

                    b.HasIndex("Sellerid");

                    b.ToTable("salesRecords");
                });

            modelBuilder.Entity("ProjetoWebMvc.Models.Seller", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BaseSalary");

                    b.Property<DateTime>("Birthdate");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("ProjetoWebMvc.Models.SalesRecord", b =>
                {
                    b.HasOne("ProjetoWebMvc.Models.Seller", "Seller")
                        .WithMany("sales")
                        .HasForeignKey("Sellerid");
                });

            modelBuilder.Entity("ProjetoWebMvc.Models.Seller", b =>
                {
                    b.HasOne("ProjetoWebMvc.Models.Department", "Department")
                        .WithMany("Sellers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
