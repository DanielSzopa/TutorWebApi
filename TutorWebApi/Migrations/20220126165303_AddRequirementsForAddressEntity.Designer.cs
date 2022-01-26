﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TutorWebApi.Infrastructure;

#nullable disable

namespace TutorWebApi.Migrations
{
    [DbContext(typeof(TutorWebApiDbContext))]
    [Migration("20220126165303_AddRequirementsForAddressEntity")]
    partial class AddRequirementsForAddressEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TutorWebApi.Domain.Achievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifyById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ProfilId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfilId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccommodationNumber")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifyById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PosteCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("UserRef")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserRef")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Advert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifyById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Adverts");
                });

            modelBuilder.Entity("TutorWebApi.Domain.AdvertContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdvertRef")
                        .HasColumnType("int");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ModifyById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdvertRef")
                        .IsUnique();

                    b.ToTable("AdvertContacts");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Comment", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifyById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "ProfileId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifyById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Like", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProfileId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifyById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserRef")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserRef")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifyById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9349),
                            IsActive = true,
                            Name = "Polish"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9395),
                            IsActive = true,
                            Name = "English"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9397),
                            IsActive = true,
                            Name = "French"
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9399),
                            IsActive = true,
                            Name = "German"
                        },
                        new
                        {
                            Id = 5,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9401),
                            IsActive = true,
                            Name = "Front-end Programming"
                        },
                        new
                        {
                            Id = 6,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9404),
                            IsActive = true,
                            Name = "Back-End Programming"
                        },
                        new
                        {
                            Id = 7,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9406),
                            IsActive = true,
                            Name = "Database"
                        },
                        new
                        {
                            Id = 8,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9408),
                            IsActive = true,
                            Name = "Maths"
                        },
                        new
                        {
                            Id = 9,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9410),
                            IsActive = true,
                            Name = "Physics"
                        },
                        new
                        {
                            Id = 10,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9412),
                            IsActive = true,
                            Name = "Chemistry"
                        },
                        new
                        {
                            Id = 11,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9414),
                            IsActive = true,
                            Name = "Geography"
                        },
                        new
                        {
                            Id = 12,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9416),
                            IsActive = true,
                            Name = "History"
                        },
                        new
                        {
                            Id = 13,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9417),
                            IsActive = true,
                            Name = "Science"
                        },
                        new
                        {
                            Id = 14,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9419),
                            IsActive = true,
                            Name = "Art"
                        },
                        new
                        {
                            Id = 15,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9421),
                            IsActive = true,
                            Name = "It"
                        },
                        new
                        {
                            Id = 16,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9423),
                            IsActive = true,
                            Name = "Technology"
                        },
                        new
                        {
                            Id = 17,
                            CreateDate = new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9424),
                            IsActive = true,
                            Name = "Business Studies"
                        });
                });

            modelBuilder.Entity("TutorWebApi.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreateById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ModifyById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Achievement", b =>
                {
                    b.HasOne("TutorWebApi.Domain.Profile", "Profil")
                        .WithMany("Achievements")
                        .HasForeignKey("ProfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profil");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Address", b =>
                {
                    b.HasOne("TutorWebApi.Domain.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("TutorWebApi.Domain.Address", "UserRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Advert", b =>
                {
                    b.HasOne("TutorWebApi.Domain.Profile", "Profil")
                        .WithMany("Adverts")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TutorWebApi.Domain.Subject", "Subject")
                        .WithMany("Adverts")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profil");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("TutorWebApi.Domain.AdvertContact", b =>
                {
                    b.HasOne("TutorWebApi.Domain.Advert", "Advert")
                        .WithOne("AdvertContact")
                        .HasForeignKey("TutorWebApi.Domain.AdvertContact", "AdvertRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advert");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Comment", b =>
                {
                    b.HasOne("TutorWebApi.Domain.Profile", "Profile")
                        .WithMany("Comments")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TutorWebApi.Domain.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Profile");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Experience", b =>
                {
                    b.HasOne("TutorWebApi.Domain.Profile", "Profile")
                        .WithMany("Experiences")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Like", b =>
                {
                    b.HasOne("TutorWebApi.Domain.Profile", "Profile")
                        .WithMany("Likes")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TutorWebApi.Domain.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Profile");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Profile", b =>
                {
                    b.HasOne("TutorWebApi.Domain.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("TutorWebApi.Domain.Profile", "UserRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Advert", b =>
                {
                    b.Navigation("AdvertContact")
                        .IsRequired();
                });

            modelBuilder.Entity("TutorWebApi.Domain.Profile", b =>
                {
                    b.Navigation("Achievements");

                    b.Navigation("Adverts");

                    b.Navigation("Comments");

                    b.Navigation("Experiences");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("TutorWebApi.Domain.Subject", b =>
                {
                    b.Navigation("Adverts");
                });

            modelBuilder.Entity("TutorWebApi.Domain.User", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Profile")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
