﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user1@gmail.com",
                            Name = "User 1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user2@gmail.com",
                            Name = "User 2"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user3@gmail.com",
                            Name = "User 3"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user4@gmail.com",
                            Name = "User 4"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}