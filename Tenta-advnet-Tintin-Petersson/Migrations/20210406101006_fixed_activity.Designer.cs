﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tenta_advnet_Tintin_Petersson;

namespace Tenta_advnet_Tintin_Petersson.Migrations
{
    [DbContext(typeof(HamsterDbContext))]
    [Migration("20210406101006_fixed_activity")]
    partial class fixed_activity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tenta_advnet_Tintin_Petersson.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Logg_ActivitiesId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Logg_ActivitiesId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Tenta_advnet_Tintin_Petersson.Cage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cages");
                });

            modelBuilder.Entity("Tenta_advnet_Tintin_Petersson.Cage_Buddies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CageId")
                        .HasColumnType("int");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CageId");

                    b.ToTable("Cage_Buddies");
                });

            modelBuilder.Entity("Tenta_advnet_Tintin_Petersson.ExerciseArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ExerciseAreas");
                });

            modelBuilder.Entity("Tenta_advnet_Tintin_Petersson.Hamster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("Cage_BuddiesId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CheckInTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeOfLastExercise")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("Cage_BuddiesId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Hamsters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 4,
                            Gender = 0,
                            Name = "Rufus",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 2,
                            Age = 12,
                            Gender = 1,
                            Name = "Lisa",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 3,
                            Age = 11,
                            Gender = 0,
                            Name = "Fluff",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 4,
                            Age = 10,
                            Gender = 0,
                            Name = "Nibbler",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 5,
                            Age = 9,
                            Gender = 0,
                            Name = "Sneaky",
                            OwnerId = 3
                        },
                        new
                        {
                            Id = 6,
                            Age = 8,
                            Gender = 1,
                            Name = "Sussi",
                            OwnerId = 3
                        },
                        new
                        {
                            Id = 7,
                            Age = 7,
                            Gender = 1,
                            Name = "Mulan",
                            OwnerId = 4
                        },
                        new
                        {
                            Id = 8,
                            Age = 6,
                            Gender = 1,
                            Name = "Miss Diggy",
                            OwnerId = 5
                        },
                        new
                        {
                            Id = 9,
                            Age = 5,
                            Gender = 0,
                            Name = "Kalle",
                            OwnerId = 6
                        },
                        new
                        {
                            Id = 10,
                            Age = 4,
                            Gender = 0,
                            Name = "Kurt",
                            OwnerId = 7
                        },
                        new
                        {
                            Id = 11,
                            Age = 4,
                            Gender = 1,
                            Name = "Starlight",
                            OwnerId = 7
                        },
                        new
                        {
                            Id = 12,
                            Age = 3,
                            Gender = 0,
                            Name = "Chivas",
                            OwnerId = 8
                        },
                        new
                        {
                            Id = 13,
                            Age = 3,
                            Gender = 1,
                            Name = "Malin",
                            OwnerId = 9
                        },
                        new
                        {
                            Id = 14,
                            Age = 24,
                            Gender = 0,
                            Name = "Bulle",
                            OwnerId = 10
                        },
                        new
                        {
                            Id = 15,
                            Age = 23,
                            Gender = 0,
                            Name = "Beppe",
                            OwnerId = 11
                        },
                        new
                        {
                            Id = 16,
                            Age = 22,
                            Gender = 1,
                            Name = "Bobo",
                            OwnerId = 12
                        },
                        new
                        {
                            Id = 17,
                            Age = 21,
                            Gender = 1,
                            Name = "Robin",
                            OwnerId = 13
                        },
                        new
                        {
                            Id = 18,
                            Age = 20,
                            Gender = 1,
                            Name = "Amber",
                            OwnerId = 14
                        },
                        new
                        {
                            Id = 19,
                            Age = 19,
                            Gender = 1,
                            Name = "Kimber",
                            OwnerId = 15
                        },
                        new
                        {
                            Id = 20,
                            Age = 18,
                            Gender = 1,
                            Name = "Ruby",
                            OwnerId = 16
                        },
                        new
                        {
                            Id = 21,
                            Age = 16,
                            Gender = 1,
                            Name = "Fiffi",
                            OwnerId = 17
                        },
                        new
                        {
                            Id = 22,
                            Age = 16,
                            Gender = 1,
                            Name = "Neko",
                            OwnerId = 18
                        },
                        new
                        {
                            Id = 23,
                            Age = 15,
                            Gender = 0,
                            Name = "Clint",
                            OwnerId = 19
                        },
                        new
                        {
                            Id = 24,
                            Age = 14,
                            Gender = 0,
                            Name = "Sauron",
                            OwnerId = 20
                        },
                        new
                        {
                            Id = 25,
                            Age = 12,
                            Gender = 1,
                            Name = "Gittan",
                            OwnerId = 21
                        },
                        new
                        {
                            Id = 26,
                            Age = 110,
                            Gender = 0,
                            Name = "Crawler",
                            OwnerId = 22
                        },
                        new
                        {
                            Id = 27,
                            Age = 9,
                            Gender = 1,
                            Name = "Mimmi",
                            OwnerId = 23
                        },
                        new
                        {
                            Id = 28,
                            Age = 8,
                            Gender = 0,
                            Name = "Marvel",
                            OwnerId = 24
                        },
                        new
                        {
                            Id = 29,
                            Age = 7,
                            Gender = 0,
                            Name = "Storm",
                            OwnerId = 25
                        },
                        new
                        {
                            Id = 30,
                            Age = 6,
                            Gender = 1,
                            Name = "Busan",
                            OwnerId = 26
                        });
                });

            modelBuilder.Entity("Tenta_advnet_Tintin_Petersson.Logg_Activities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HamsterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HamsterId");

                    b.ToTable("Logg_Activities");
                });

            modelBuilder.Entity("Tenta_advnet_Tintin_Petersson.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kallegurra Aktersnurra"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Carl Hamilton"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lisa Nilsson"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Jan Hallgren"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Ottilla Murkwood"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Anfers Murkwood"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Anna Book"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Pernilla Wahlgren"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Bianca Ingrosso"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Lorenzo Lamas"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Bobby Ewing"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Hedy Lamar"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Bette Davis"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Kim Carnes"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Mork of Ork"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Mindy Mendel"
                        },
                        new
                        {
                            Id = 17,
                            Name = "GW Hansson"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Pia Hansson"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Bo Ek"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Anna Al"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Hans Björk"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Carita Gran"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Mia Eriksson"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Anna Linström"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Lennart Berg"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Bo Bergman"
                        });
                });

            modelBuilder.Entity("Tenta_advnet_Tintin_Petersson.Activity", b =>
                {
                    b.HasOne("Tenta_advnet_Tintin_Petersson.Logg_Activities", "Logg_Activities")
                        .WithMany("Activities")
                        .HasForeignKey("Logg_ActivitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Logg_Activities");
                });

            modelBuilder.Entity("Tenta_advnet_Tintin_Petersson.Cage_Buddies", b =>
                {
                    b.HasOne("Tenta_advnet_Tintin_Petersson.Cage", "Cage")
                        .WithMany()
                        .HasForeignKey("CageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cage");
                });

            modelBuilder.Entity("Tenta_advnet_Tintin_Petersson.Hamster", b =>
                {
                    b.HasOne("Tenta_advnet_Tintin_Petersson.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId");

                    b.HasOne("Tenta_advnet_Tintin_Petersson.Cage_Buddies", "Cage_Buddies")
                        .WithMany()
                        .HasForeignKey("Cage_BuddiesId");

                    b.HasOne("Tenta_advnet_Tintin_Petersson.Owner", "Owner")
                        .WithMany("Hamsters")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Cage_Buddies");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Tenta_advnet_Tintin_Petersson.Logg_Activities", b =>
                {
                    b.HasOne("Tenta_advnet_Tintin_Petersson.Hamster", "Hamster")
                        .WithMany("Logg_Activites")
                        .HasForeignKey("HamsterId");

                    b.Navigation("Hamster");
                });

            modelBuilder.Entity("Tenta_advnet_Tintin_Petersson.Hamster", b =>
                {
                    b.Navigation("Logg_Activites");
                });

            modelBuilder.Entity("Tenta_advnet_Tintin_Petersson.Logg_Activities", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("Tenta_advnet_Tintin_Petersson.Owner", b =>
                {
                    b.Navigation("Hamsters");
                });
#pragma warning restore 612, 618
        }
    }
}
