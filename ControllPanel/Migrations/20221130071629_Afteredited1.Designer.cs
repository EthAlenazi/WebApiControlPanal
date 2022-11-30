﻿// <auto-generated />
using ControllPanel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControllPanel.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221130071629_Afteredited1")]
    partial class Afteredited1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ControllPanel.Data.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFemale")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MobileNumber")
                        .HasColumnType("bigint");

                    b.Property<long>("PersonalId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProfilePhotopath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            Email = "Alotio123@gmail.com",
                            FirstName = "Ahmad",
                            IsActive = true,
                            IsAdmin = true,
                            IsFemale = false,
                            LastName = "Saeed",
                            MobileNumber = 966565433332L,
                            PersonalId = 12345674321L,
                            ProfilePhotopath = "C:\\Users\\Atheer Alonizi\\Pictures\\Photos\\User_1.PNG"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            Email = "Sa7ar@gmail.com",
                            FirstName = "Sahar",
                            IsActive = true,
                            IsAdmin = false,
                            IsFemale = true,
                            LastName = "Mohammed",
                            MobileNumber = 966545321888L,
                            PersonalId = 12343215432L,
                            ProfilePhotopath = "C:\\Users\\Atheer Alonizi\\Pictures\\Photos\\User_2.PNG"
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 3,
                            Email = "Saleh11@gmail.com",
                            FirstName = "Fahad",
                            IsActive = true,
                            IsAdmin = true,
                            IsFemale = true,
                            LastName = "Saleh",
                            MobileNumber = 966535432221L,
                            PersonalId = 1221376459L,
                            ProfilePhotopath = "C:\\Users\\Atheer Alonizi\\Pictures\\Photos\\User_3.PNG"
                        });
                });

            modelBuilder.Entity("ControllPanel.Data.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Riyadh",
                            Country = "Saudi Arabia",
                            Street = "Olaya Street",
                            ZipCode = 11461
                        },
                        new
                        {
                            Id = 2,
                            City = "Khubar",
                            Country = "Saudi Arabia",
                            Street = "king abdulaziz road",
                            ZipCode = 31952
                        },
                        new
                        {
                            Id = 3,
                            City = "Jeddah",
                            Country = "Saudi Arabia",
                            Street = "Juffali Building, Madinah Road",
                            ZipCode = 21442
                        });
                });

            modelBuilder.Entity("ControllPanel.Data.Account", b =>
                {
                    b.HasOne("ControllPanel.Data.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
