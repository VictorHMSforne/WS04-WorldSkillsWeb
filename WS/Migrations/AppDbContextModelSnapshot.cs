﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WS.Context;

#nullable disable

namespace WS.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WS.Models.Pressao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .HasColumnType("longtext");

                    b.Property<int>("Diastole")
                        .HasColumnType("int");

                    b.Property<string>("Hora")
                        .HasColumnType("longtext");

                    b.Property<int>("Sistole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pressao");
                });
#pragma warning restore 612, 618
        }
    }
}
