﻿// <auto-generated />
using System;
using E_commerce.Database.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_commerce.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.Property<int>("Product_Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Total_Amount")
                        .HasColumnType("int");

                    b.HasKey("Cart_Id");

                    b.ToTable("Carts");
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

                    b.Property<string>("ImagePath")
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

                    b.Property<int>("Ratings")
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

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("E_commerce.Database.Entity.Seller", b =>
                {
                    b.Property<int>("Seller_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Seller_Id"));

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
#pragma warning restore 612, 618
        }
    }
}