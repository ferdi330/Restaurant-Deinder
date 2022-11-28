﻿// <auto-generated />
using System;
using D_Einder_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace D_Einder_MVC.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20221124153352_Oke")]
    partial class Oke
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("D_Einder_MVC.Models.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.DrinkBestellingen", b =>
                {
                    b.Property<int>("TafelId")
                        .HasColumnType("int");

                    b.Property<int>("DrinkId")
                        .HasColumnType("int");

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.HasKey("TafelId", "DrinkId");

                    b.HasIndex("DrinkId");

                    b.ToTable("DrinkBestelling");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Financie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DrinkBestellingenDrinkId")
                        .HasColumnType("int");

                    b.Property<int?>("DrinkBestellingenTafelId")
                        .HasColumnType("int");

                    b.Property<int?>("DrinkId")
                        .HasColumnType("int");

                    b.Property<string>("Maand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MenusId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderMenuNaam")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("OrderReserveringenId")
                        .HasColumnType("int");

                    b.Property<int?>("ReserveringenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DrinkId");

                    b.HasIndex("MenusId");

                    b.HasIndex("ReserveringenId");

                    b.HasIndex("DrinkBestellingenTafelId", "DrinkBestellingenDrinkId");

                    b.HasIndex("OrderReserveringenId", "OrderMenuNaam");

                    b.ToTable("Financie");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Gerechten", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GerechtSoort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gerechten");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.GerechtenIngredienten", b =>
                {
                    b.Property<int>("GerechtenId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientenId")
                        .HasColumnType("int");

                    b.Property<int>("Hoeveelheid")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("GerechtenId", "IngredientenId");

                    b.HasIndex("IngredientenId");

                    b.ToTable("GerechtenIngredienten");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Ingredienten", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Eenheid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredienten");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MenuSoortId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prijs")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuSoortId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.MenuGerechten", b =>
                {
                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("GerechtenId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("MenuId", "GerechtenId");

                    b.HasIndex("GerechtenId");

                    b.ToTable("MenuGerechten");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.MenuSoort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MenuSoort");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Order", b =>
                {
                    b.Property<int>("ReserveringenId")
                        .HasColumnType("int");

                    b.Property<string>("MenuNaam")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Hoeveelheid")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("MenuId")
                        .HasColumnType("int");

                    b.HasKey("ReserveringenId", "MenuNaam");

                    b.HasIndex("MenuId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Reserveringen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TafelId")
                        .HasColumnType("int");

                    b.Property<string>("Tijd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Woonplaats")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TafelId");

                    b.ToTable("Reserveringen");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Tafel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tafel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.DrinkBestellingen", b =>
                {
                    b.HasOne("D_Einder_MVC.Models.Drink", "Drink")
                        .WithMany("Drinkbestelling")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("D_Einder_MVC.Models.Tafel", "Tafel")
                        .WithMany("Drinkbestelling")
                        .HasForeignKey("TafelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("Tafel");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Financie", b =>
                {
                    b.HasOne("D_Einder_MVC.Models.Drink", "Drink")
                        .WithMany()
                        .HasForeignKey("DrinkId");

                    b.HasOne("D_Einder_MVC.Models.Menu", "Menus")
                        .WithMany()
                        .HasForeignKey("MenusId");

                    b.HasOne("D_Einder_MVC.Models.Reserveringen", "Reserveringen")
                        .WithMany()
                        .HasForeignKey("ReserveringenId");

                    b.HasOne("D_Einder_MVC.Models.DrinkBestellingen", "DrinkBestellingen")
                        .WithMany()
                        .HasForeignKey("DrinkBestellingenTafelId", "DrinkBestellingenDrinkId");

                    b.HasOne("D_Einder_MVC.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderReserveringenId", "OrderMenuNaam");

                    b.Navigation("Drink");

                    b.Navigation("DrinkBestellingen");

                    b.Navigation("Menus");

                    b.Navigation("Order");

                    b.Navigation("Reserveringen");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.GerechtenIngredienten", b =>
                {
                    b.HasOne("D_Einder_MVC.Models.Gerechten", "Gerechten")
                        .WithMany()
                        .HasForeignKey("GerechtenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("D_Einder_MVC.Models.Ingredienten", "Ingredienten")
                        .WithMany()
                        .HasForeignKey("IngredientenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gerechten");

                    b.Navigation("Ingredienten");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Menu", b =>
                {
                    b.HasOne("D_Einder_MVC.Models.MenuSoort", "MenuSoort")
                        .WithMany("Menus")
                        .HasForeignKey("MenuSoortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuSoort");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.MenuGerechten", b =>
                {
                    b.HasOne("D_Einder_MVC.Models.Gerechten", "Gerechten")
                        .WithMany()
                        .HasForeignKey("GerechtenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("D_Einder_MVC.Models.Menu", "Menus")
                        .WithMany("MenuGerechten")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gerechten");

                    b.Navigation("Menus");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Order", b =>
                {
                    b.HasOne("D_Einder_MVC.Models.Menu", "Menu")
                        .WithMany("Order")
                        .HasForeignKey("MenuId");

                    b.HasOne("D_Einder_MVC.Models.Reserveringen", "Reserveringen")
                        .WithMany("Order")
                        .HasForeignKey("ReserveringenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Reserveringen");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Reserveringen", b =>
                {
                    b.HasOne("D_Einder_MVC.Models.Tafel", "Tafel")
                        .WithMany()
                        .HasForeignKey("TafelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tafel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Drink", b =>
                {
                    b.Navigation("Drinkbestelling");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Menu", b =>
                {
                    b.Navigation("MenuGerechten");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.MenuSoort", b =>
                {
                    b.Navigation("Menus");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Reserveringen", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("D_Einder_MVC.Models.Tafel", b =>
                {
                    b.Navigation("Drinkbestelling");
                });
#pragma warning restore 612, 618
        }
    }
}
