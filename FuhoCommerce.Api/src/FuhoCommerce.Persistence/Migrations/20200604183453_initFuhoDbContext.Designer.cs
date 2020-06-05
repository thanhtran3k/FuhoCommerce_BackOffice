﻿// <auto-generated />
using System;
using FuhoCommerce.Persistence.EFDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FuhoCommerce.Persistence.Migrations
{
    [DbContext(typeof(FuhoDbContext))]
    [Migration("20200604183453_initFuhoDbContext")]
    partial class initFuhoDbContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.Buyer", b =>
                {
                    b.Property<Guid>("BuyerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuyerId");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.BuyerCart", b =>
                {
                    b.Property<Guid>("BuyerCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuyerCartId");

                    b.HasIndex("BuyerId")
                        .IsUnique();

                    b.ToTable("BuyerCarts");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.BuyerComment", b =>
                {
                    b.Property<Guid>("BuyerCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuyerCommentId");

                    b.HasIndex("ProductId");

                    b.ToTable("BuyerComments");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.BuyerHistory", b =>
                {
                    b.Property<Guid>("BuyerHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuyerHistoryId");

                    b.HasIndex("BuyerId");

                    b.ToTable("BuyerHistories");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.BuyerShippingInfo", b =>
                {
                    b.Property<Guid>("BuyerShippingInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("BuyerShippingInfoId");

                    b.HasIndex("BuyerId");

                    b.ToTable("BuyerShippingInfos");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(15);

                    b.Property<string>("Thumbnail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.FuhoWallet", b =>
                {
                    b.Property<Guid>("FuhoWalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FuhoCoin")
                        .HasColumnType("money");

                    b.Property<DateTime>("FuhoCoinExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FuhoMoney")
                        .HasColumnType("money");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FuhoWalletId");

                    b.HasIndex("BuyerId");

                    b.ToTable("FuhoWallets");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Freight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShipAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipPostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipRegion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShipVia")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ShipperId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ShipperId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BuyerCartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuyerHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReorderLevel")
                        .HasColumnType("int");

                    b.Property<string>("Sku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<Guid?>("SupplierCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("BuyerCartId");

                    b.HasIndex("BuyerHistoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierCategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.ProductOption", b =>
                {
                    b.Property<Guid>("ProductOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Optionkey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductOptionId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOptions");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.Shipper", b =>
                {
                    b.Property<int>("ShipperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShipperId");

                    b.ToTable("Shippers");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.Supplier", b =>
                {
                    b.Property<Guid>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RatingReceived")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.SupplierCategory", b =>
                {
                    b.Property<Guid>("SupplierCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierCategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierCategories");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.BuyerCart", b =>
                {
                    b.HasOne("FuhoCommerce.Domain.Entities.Buyer", "Buyer")
                        .WithOne("BuyerCart")
                        .HasForeignKey("FuhoCommerce.Domain.Entities.BuyerCart", "BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.BuyerComment", b =>
                {
                    b.HasOne("FuhoCommerce.Domain.Entities.Product", "Product")
                        .WithMany("BuyerComments")
                        .HasForeignKey("ProductId")
                        .IsRequired();
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.BuyerHistory", b =>
                {
                    b.HasOne("FuhoCommerce.Domain.Entities.Buyer", null)
                        .WithMany("BuyerHistories")
                        .HasForeignKey("BuyerId");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.BuyerShippingInfo", b =>
                {
                    b.HasOne("FuhoCommerce.Domain.Entities.Buyer", "Buyer")
                        .WithMany("BuyerShippingInfos")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.FuhoWallet", b =>
                {
                    b.HasOne("FuhoCommerce.Domain.Entities.Buyer", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.Order", b =>
                {
                    b.HasOne("FuhoCommerce.Domain.Entities.Buyer", "Buyer")
                        .WithMany("Orders")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FuhoCommerce.Domain.Entities.Shipper", "Shipper")
                        .WithMany("Orders")
                        .HasForeignKey("ShipperId");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("FuhoCommerce.Domain.Entities.Order", "Order")
                        .WithOne("OrderDetail")
                        .HasForeignKey("FuhoCommerce.Domain.Entities.OrderDetail", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FuhoCommerce.Domain.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.Product", b =>
                {
                    b.HasOne("FuhoCommerce.Domain.Entities.BuyerCart", null)
                        .WithMany("Products")
                        .HasForeignKey("BuyerCartId");

                    b.HasOne("FuhoCommerce.Domain.Entities.BuyerHistory", null)
                        .WithMany("Products")
                        .HasForeignKey("BuyerHistoryId");

                    b.HasOne("FuhoCommerce.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FuhoCommerce.Domain.Entities.SupplierCategory", null)
                        .WithMany("Products")
                        .HasForeignKey("SupplierCategoryId");

                    b.HasOne("FuhoCommerce.Domain.Entities.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.ProductOption", b =>
                {
                    b.HasOne("FuhoCommerce.Domain.Entities.Product", "Product")
                        .WithMany("ProductOptions")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("FuhoCommerce.Domain.Entities.SupplierCategory", b =>
                {
                    b.HasOne("FuhoCommerce.Domain.Entities.Supplier", "Supplier")
                        .WithMany("SupplierCategories")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
