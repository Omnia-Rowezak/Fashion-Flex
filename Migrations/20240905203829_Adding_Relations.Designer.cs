﻿// <auto-generated />
using System;
using Fashion_Flex.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fashion_Flex.Migrations
{
    [DbContext(typeof(FFContext))]
    [Migration("20240905203829_Adding_Relations")]
    partial class Adding_Relations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fashion_Flex.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Account_Creation_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Date_Of_Birth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("bit");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_Country_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Favorite_Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Brand_Id")
                        .HasColumnType("int");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Brand_Id");

                    b.HasIndex("Customer_Id");

                    b.ToTable("Favorite_Brands");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Order_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Order_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Payment_Id")
                        .HasColumnType("int");

                    b.Property<string>("Shipping_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total_Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Tracking_Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Customer_Id");

                    b.HasIndex("Payment_Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Order_Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Order_Id")
                        .HasColumnType("int");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Order_Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("Order_Items");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Payment_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payment_Method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Payment_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transaction_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Order_Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Added_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Available_Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Brand_Id")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Brand_Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("Review_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("is_verified_purchase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Customer_Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Favorite_Brand", b =>
                {
                    b.HasOne("Fashion_Flex.Models.Brand", "Brand")
                        .WithMany("FavoriteBrands")
                        .HasForeignKey("Brand_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fashion_Flex.Models.Customer", "Customer")
                        .WithMany("Favorite_Brands")
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Order", b =>
                {
                    b.HasOne("Fashion_Flex.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fashion_Flex.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("Payment_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Order_Item", b =>
                {
                    b.HasOne("Fashion_Flex.Models.Order", "Order")
                        .WithMany("Order_Items")
                        .HasForeignKey("Order_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fashion_Flex.Models.Product", "Product")
                        .WithMany("Order_Items")
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Payment", b =>
                {
                    b.HasOne("Fashion_Flex.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("Order_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Product", b =>
                {
                    b.HasOne("Fashion_Flex.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("Brand_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Review", b =>
                {
                    b.HasOne("Fashion_Flex.Models.Customer", "Customer")
                        .WithMany("Reviews")
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fashion_Flex.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Brand", b =>
                {
                    b.Navigation("FavoriteBrands");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Customer", b =>
                {
                    b.Navigation("Favorite_Brands");

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Order", b =>
                {
                    b.Navigation("Order_Items");
                });

            modelBuilder.Entity("Fashion_Flex.Models.Product", b =>
                {
                    b.Navigation("Order_Items");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
