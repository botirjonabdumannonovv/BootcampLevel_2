﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using N70_Entity.Persistence.DataContexts;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace N70_Entity.Persistence.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20231113131217_AddUser")]
    partial class AddUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("N70_Entity.Domain.Entities.AccessToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsRevorked")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("AccessTokens");
                });

            modelBuilder.Entity("N70_Entity.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("45467824-7527-4530-a7fe-6d38dd09a3c5"),
                            CreatedDate = new DateTime(2023, 11, 13, 13, 12, 17, 412, DateTimeKind.Utc).AddTicks(4027),
                            IsDisabled = false,
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("fb05f885-807c-445a-aaff-673ee99f46f3"),
                            CreatedDate = new DateTime(2023, 11, 13, 13, 12, 17, 412, DateTimeKind.Utc).AddTicks(4032),
                            IsDisabled = false,
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("1b375629-4f3f-4c23-806f-bd0f758ad683"),
                            CreatedDate = new DateTime(2023, 11, 13, 13, 12, 17, 412, DateTimeKind.Utc).AddTicks(4034),
                            IsDisabled = false,
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = 1
                        });
                });

            modelBuilder.Entity("N70_Entity.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsEmailAddressVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0238e5c5-28cd-4b5a-8e17-5700e5840983"),
                            Age = 1,
                            EmailAddress = "thedavlativich@gmail.com",
                            FirstName = "John",
                            IsEmailAddressVerified = true,
                            LastName = "Doe",
                            PasswordHash = "",
                            RoleId = new Guid("45467824-7527-4530-a7fe-6d38dd09a3c5")
                        });
                });

            modelBuilder.Entity("N70_Entity.Domain.Entities.AccessToken", b =>
                {
                    b.HasOne("N70_Entity.Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("N70_Entity.Domain.Entities.AccessToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("N70_Entity.Domain.Entities.User", b =>
                {
                    b.HasOne("N70_Entity.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
