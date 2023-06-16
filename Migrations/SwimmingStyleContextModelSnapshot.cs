﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwimmingStyleAPI.DbContexts;

#nullable disable

namespace SwimmingStyleAPI.Migrations
{
    [DbContext(typeof(SwimmingStyleContext))]
    partial class SwimmingStyleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("SwimmingStyleAPI.Entitites.StatsSwimmingstyleEntities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Difficulty")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Endurance")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Speed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SwimmingStyleEntitiesId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Technique")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SwimmingStyleEntitiesId");

                    b.ToTable("StatsSwimmingStyles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Difficulty = 2,
                            Endurance = 2,
                            Speed = 2,
                            SwimmingStyleEntitiesId = 1,
                            Technique = 2
                        },
                        new
                        {
                            Id = 2,
                            Difficulty = 3,
                            Endurance = 3,
                            Speed = 3,
                            SwimmingStyleEntitiesId = 1,
                            Technique = 4
                        },
                        new
                        {
                            Id = 3,
                            Difficulty = 4,
                            Endurance = 4,
                            Speed = 4,
                            SwimmingStyleEntitiesId = 2,
                            Technique = 4
                        },
                        new
                        {
                            Id = 4,
                            Difficulty = 5,
                            Endurance = 5,
                            Speed = 5,
                            SwimmingStyleEntitiesId = 2,
                            Technique = 5
                        });
                });

            modelBuilder.Entity("SwimmingStyleAPI.Entitites.SwimmingStyleEntities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SwimmingStyles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The front crawl or forward crawl, also known as the Australi",
                            Image = "freeStyle",
                            Name = "Crawl"
                        },
                        new
                        {
                            Id = 2,
                            Image = "Butterfly",
                            Name = "Butterfly"
                        });
                });

            modelBuilder.Entity("SwimmingStyleAPI.Entitites.StatsSwimmingstyleEntities", b =>
                {
                    b.HasOne("SwimmingStyleAPI.Entitites.SwimmingStyleEntities", "SwimmingStyleEntitie")
                        .WithMany("StatsOfSwimmingStyle")
                        .HasForeignKey("SwimmingStyleEntitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SwimmingStyleEntitie");
                });

            modelBuilder.Entity("SwimmingStyleAPI.Entitites.SwimmingStyleEntities", b =>
                {
                    b.Navigation("StatsOfSwimmingStyle");
                });
#pragma warning restore 612, 618
        }
    }
}
