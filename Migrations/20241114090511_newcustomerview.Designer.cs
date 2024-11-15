﻿// <auto-generated />
using System;
using E_commerce.Database.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_commerce.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241114090511_newcustomerview")]
    partial class newcustomerview
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_commerce.Database.Entity.Cart", b =>
                {
                    b.Property<int>("Cart_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cart_Id"));

                    b.Property<string>("Customer_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.HasKey("Cart_Id");

                    b.HasIndex("Customer_Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("E_commerce.Database.Entity.CartItem", b =>
                {
                    b.Property<int>("CartItem_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartItem_Id"));

                    b.Property<int>("Cart_Id")
                        .HasColumnType("int");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartItem_Id");

                    b.HasIndex("Cart_Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("E_commerce.Database.Entity.Customer", b =>
                {
                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Customer_Id"));

                    b.Property<string>("Customer_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_DOB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Customer_IsActive")
                        .HasColumnType("int");

                    b.Property<string>("Customer_Landmark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_Pincode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Customer_State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Customer_Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("E_commerce.Database.Entity.Electronic_Product", b =>
                {
                    b.Property<int>("Product_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_Id"));

                    b.Property<int>("Battery_capacity")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operating_System")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Product_Price")
                        .HasColumnType("int");

                    b.Property<int>("Product_Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RAM")
                        .HasColumnType("int");

                    b.Property<int>("ROM")
                        .HasColumnType("int");

                    b.Property<int>("Ratings")
                        .HasColumnType("int");

                    b.Property<int>("Seller_Id")
                        .HasColumnType("int");

                    b.Property<string>("Seller_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Product_Id");

                    b.ToTable("Electronics");
                });

            modelBuilder.Entity("E_commerce.Database.Entity.Order", b =>
                {
                    b.Property<int>("Order_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Order_Id"));

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ordered_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Ordered_Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.Property<int>("Seller_Id")
                        .HasColumnType("int");

                    b.HasKey("Order_Id");

                    b.HasIndex("Customer_Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("E_commerce.Database.Entity.Review", b =>
                {
                    b.Property<int>("Review_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Review_Id"));

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("Review_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Review_Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Review_Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("E_commerce.Database.Entity.Seller", b =>
                {
                    b.Property<int>("Seller_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Seller_Id"));

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Seller_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seller_ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seller_Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seller_DOB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seller_District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seller_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seller_Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seller_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seller_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seller_Pincode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Seller_State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seller_isactive")
                        .HasColumnType("int");

                    b.HasKey("Seller_Id");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("E_commerce.Database.Entity.Cart", b =>
                {
                    b.HasOne("E_commerce.Database.Entity.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("E_commerce.Database.Entity.CartItem", b =>
                {
                    b.HasOne("E_commerce.Database.Entity.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("Cart_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_commerce.Database.Entity.Electronic_Product", "Product")
                        .WithMany()
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("E_commerce.Database.Entity.Order", b =>
                {
                    b.HasOne("E_commerce.Database.Entity.Customer", "Customers")
                        .WithMany()
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_commerce.Database.Entity.Electronic_Product", "product")
                        .WithMany()
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");

                    b.Navigation("product");
                });

            modelBuilder.Entity("E_commerce.Database.Entity.Cart", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
