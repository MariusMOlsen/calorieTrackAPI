﻿// <auto-generated />
using System;
using CalorieTrack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CalorieTrack.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230928155321_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CalorieTrack.Model.Diary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NutritionGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("diaries");
                });

            modelBuilder.Entity("CalorieTrack.Model.DiaryItem", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DiaryGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<Guid>("ItemGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ItemType")
                        .HasColumnType("int");

                    b.HasKey("Guid");

                    b.ToTable("DiaryItems");
                });

            modelBuilder.Entity("CalorieTrack.Model.Food", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountOfUnit")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NutritionGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("CalorieTrack.Model.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NutritionGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("meals");
                });

            modelBuilder.Entity("CalorieTrack.Model.MealItem", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<Guid>("ItemGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MealGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MealItemType")
                        .HasColumnType("int");

                    b.HasKey("Guid");

                    b.ToTable("mealsItem");
                });

            modelBuilder.Entity("CalorieTrack.Model.Nutrition", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Carbohydrates")
                        .HasColumnType("int");

                    b.Property<int>("Fat")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Protein")
                        .HasColumnType("int");

                    b.Property<Guid?>("unitDefinitionGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Guid");

                    b.ToTable("Nutritions");
                });

            modelBuilder.Entity("CalorieTrack.Model.Recepie", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NutritionGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Guid");

                    b.ToTable("Recepies");
                });

            modelBuilder.Entity("CalorieTrack.Model.RecepieItem", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FoodGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<Guid>("RecepieGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Guid");

                    b.ToTable("RecepieItems");
                });

            modelBuilder.Entity("CalorieTrack.Model.UnitDefinition", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("defaultAmount")
                        .HasColumnType("int");

                    b.HasKey("Guid");

                    b.ToTable("UnitDefinition");
                });
#pragma warning restore 612, 618
        }
    }
}
