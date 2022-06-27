﻿// <auto-generated />
using System;
using FifthMiniProject.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FifthMiniProject.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FifthMiniProject.Domain.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int>("BuyerPersonId")
                        .HasColumnType("int");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex("BuyerPersonId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FifthMiniProject.Domain.Entities.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"), 1L, 1);

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeselNumber")
                        .IsRequired()
                        .HasColumnType("PESEL");

                    b.Property<string>("person_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("PeselNumber")
                        .IsUnique();

                    b.ToTable("People");

                    b.HasDiscriminator<string>("person_type").HasValue("person_base");
                });

            modelBuilder.Entity("FifthMiniProject.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SellerPersonId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("SellerPersonId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FifthMiniProject.Domain.Entities.Buyer", b =>
                {
                    b.HasBaseType("FifthMiniProject.Domain.Entities.Person");

                    b.Property<int>("BuyerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("EMAIL");

                    b.HasDiscriminator().HasValue("person_buyer");
                });

            modelBuilder.Entity("FifthMiniProject.Domain.Entities.Seller", b =>
                {
                    b.HasBaseType("FifthMiniProject.Domain.Entities.Person");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("person_seller");
                });

            modelBuilder.Entity("FifthMiniProject.Domain.Entities.Order", b =>
                {
                    b.HasOne("FifthMiniProject.Domain.Entities.Buyer", "Buyer")
                        .WithMany("Orders")
                        .HasForeignKey("BuyerPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("FifthMiniProject.Domain.Entities.Product", b =>
                {
                    b.HasOne("FifthMiniProject.Domain.Entities.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");

                    b.HasOne("FifthMiniProject.Domain.Entities.Seller", "Seller")
                        .WithMany("Products")
                        .HasForeignKey("SellerPersonId");

                    b.Navigation("Order");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("FifthMiniProject.Domain.Entities.Buyer", b =>
                {
                    b.OwnsOne("FifthMiniProject.Domain.Entities.CreditCard", "CreditCard", b1 =>
                        {
                            b1.Property<int>("BuyerPersonId")
                                .HasColumnType("int");

                            b1.Property<string>("CreditCardNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CvcNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("ExpirationDate")
                                .HasColumnType("datetime2");

                            b1.HasKey("BuyerPersonId");

                            b1.ToTable("CreditCards");

                            b1.WithOwner()
                                .HasForeignKey("BuyerPersonId");
                        });

                    b.Navigation("CreditCard")
                        .IsRequired();
                });

            modelBuilder.Entity("FifthMiniProject.Domain.Entities.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FifthMiniProject.Domain.Entities.Buyer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FifthMiniProject.Domain.Entities.Seller", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
