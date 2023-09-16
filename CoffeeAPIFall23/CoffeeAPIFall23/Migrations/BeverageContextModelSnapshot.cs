﻿// <auto-generated />
using System;
using CoffeeAPIFall23.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoffeeAPIFall23.Migrations
{
    [DbContext(typeof(BeverageContext))]
    partial class BeverageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoffeeAPIFall23.Models.Coffee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Characteristic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strength")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coffees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7072fa5a-a417-464d-b4bf-3b6aaa7e8260"),
                            Characteristic = "Espresso, steamed milk, and milk foam",
                            Cost = 3.45m,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg",
                            Name = "Cappuccino",
                            Strength = "Medium"
                        },
                        new
                        {
                            Id = new Guid("0de40e1c-5727-492b-94d9-efa9eefe6080"),
                            Characteristic = "Espresso",
                            Cost = 2.45m,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg",
                            Name = "Espresso",
                            Strength = "Strong"
                        },
                        new
                        {
                            Id = new Guid("258d4024-3314-43e6-97f0-b49698b05c40"),
                            Characteristic = "Espresso and steamed milk",
                            Cost = 3.45m,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg",
                            Name = "Latte",
                            Strength = "Medium"
                        },
                        new
                        {
                            Id = new Guid("78814f49-ea40-49e6-9c70-e58ddd49c681"),
                            Characteristic = "Espresso, steamed milk, milk foam, and chocolate",
                            Cost = 3.45m,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg",
                            Name = "Mocha",
                            Strength = "Medium"
                        },
                        new
                        {
                            Id = new Guid("4922e75c-9bd3-4192-9e7a-3705c600ea73"),
                            Characteristic = "Espresso and hot water",
                            Cost = 3.45m,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg",
                            Name = "Americano",
                            Strength = "Medium"
                        },
                        new
                        {
                            Id = new Guid("ff024a63-e7f1-4734-94f8-d09efd1f4be2"),
                            Characteristic = "Espresso and milk foam",
                            Cost = 3.45m,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg",
                            Name = "Macchiato",
                            Strength = "Medium"
                        },
                        new
                        {
                            Id = new Guid("4618ad48-d836-469f-9dd4-8a2cd1239a0b"),
                            Characteristic = "Espresso and steamed milk",
                            Cost = 3.45m,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0f/402px-Cappuccino_at_Sightglass_Coffee.jpg",
                            Name = "Cortado",
                            Strength = "Medium"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
