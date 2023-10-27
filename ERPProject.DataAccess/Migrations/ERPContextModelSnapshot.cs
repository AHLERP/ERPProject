﻿// <auto-generated />
using System;
using ERPProject.DataAccess.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ERPProject.DataAccess.Migrations
{
    [DbContext(typeof(ERPContext))]
    partial class ERPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ERPProject.Entity.Poco.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("AddedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("AddedUser")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("UpdatedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Brand", (string)null);
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("AddedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("AddedUser")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("UpdatedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("AddedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("AddedUser")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("UpdatedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("AddedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("AddedUser")
                        .HasColumnType("bigint");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("UpdatedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("AddedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("AddedUser")
                        .HasColumnType("bigint");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long>("OfferId")
                        .HasColumnType("bigint");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("UpdatedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("OfferId");

                    b.HasIndex("ProductId");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Offer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AddedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("AddedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("AddedUser")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("PriceStatus")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .IsFixedLength();

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .IsFixedLength();

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("UpdatedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Offer", (string)null);
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("AddedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("AddedUser")
                        .HasColumnType("bigint");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("UpdatedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Request", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("AcceptedId")
                        .HasColumnType("bigint");

                    b.Property<string>("AddedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("AddedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("AddedUser")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasMaxLength(511)
                        .HasColumnType("nvarchar(511)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("UpdatedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Request", (string)null);
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.RequestDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AddedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("AddedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("AddedUser")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<long>("RequestId")
                        .HasColumnType("bigint");

                    b.Property<string>("UpdatedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("UpdatedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestDetail", (string)null);
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("AddedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("AddedUser")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("UpdatedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Stock", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AddedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("AddedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("AddedUser")
                        .HasColumnType("bigint");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("UpdatedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProductId");

                    b.ToTable("Stock", (string)null);
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.StockDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AddedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("AddedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("AddedUser")
                        .HasColumnType("bigint");

                    b.Property<long>("DelivererId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<long>("RecieverId")
                        .HasColumnType("bigint");

                    b.Property<long>("StockId")
                        .HasColumnType("bigint");

                    b.Property<string>("UpdatedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("UpdatedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DelivererId");

                    b.HasIndex("RecieverId");

                    b.HasIndex("StockId");

                    b.ToTable("StockDetail", (string)null);
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AddedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("AddedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("AddedUser")
                        .HasColumnType("bigint");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedIPV4Address")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("UpdatedIP4VAdress")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Department", b =>
                {
                    b.HasOne("ERPProject.Entity.Poco.Company", "Company")
                        .WithMany("Departments")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("FK_Department_Company");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Invoice", b =>
                {
                    b.HasOne("ERPProject.Entity.Poco.Company", "Company")
                        .WithMany("Invoices")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("FK_Invoice_Company");

                    b.HasOne("ERPProject.Entity.Poco.Offer", "Offer")
                        .WithMany("Invoices")
                        .HasForeignKey("OfferId")
                        .IsRequired()
                        .HasConstraintName("FK_Invoice_Offer");

                    b.HasOne("ERPProject.Entity.Poco.Product", "Product")
                        .WithMany("Invoices")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Invoice_Product");

                    b.Navigation("Company");

                    b.Navigation("Offer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Product", b =>
                {
                    b.HasOne("ERPProject.Entity.Poco.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .IsRequired()
                        .HasConstraintName("FK_Product_Brand");

                    b.HasOne("ERPProject.Entity.Poco.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Product_Category");

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Request", b =>
                {
                    b.HasOne("ERPProject.Entity.Poco.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Request_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.RequestDetail", b =>
                {
                    b.HasOne("ERPProject.Entity.Poco.Product", "Product")
                        .WithMany("RequestDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_RequestDetail_Product");

                    b.HasOne("ERPProject.Entity.Poco.Request", "Request")
                        .WithMany("RequestDetails")
                        .HasForeignKey("RequestId")
                        .IsRequired()
                        .HasConstraintName("FK_RequestDetail_Request");

                    b.Navigation("Product");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Stock", b =>
                {
                    b.HasOne("ERPProject.Entity.Poco.Company", "Company")
                        .WithMany("Stocks")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("FK_Stock_Company");

                    b.HasOne("ERPProject.Entity.Poco.Product", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Stock_Product");

                    b.Navigation("Company");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.StockDetail", b =>
                {
                    b.HasOne("ERPProject.Entity.Poco.User", "Deliverer")
                        .WithMany("StockDetailDeliverers")
                        .HasForeignKey("DelivererId")
                        .IsRequired()
                        .HasConstraintName("FK_StockDetail_User1");

                    b.HasOne("ERPProject.Entity.Poco.User", "Reciever")
                        .WithMany("StockDetailRecievers")
                        .HasForeignKey("RecieverId")
                        .IsRequired()
                        .HasConstraintName("FK_StockDetail_User");

                    b.HasOne("ERPProject.Entity.Poco.Stock", "Stock")
                        .WithMany("StockDetails")
                        .HasForeignKey("StockId")
                        .IsRequired()
                        .HasConstraintName("FK_StockDetail_Stock");

                    b.Navigation("Deliverer");

                    b.Navigation("Reciever");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.UserRole", b =>
                {
                    b.HasOne("ERPProject.Entity.Poco.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_Role");

                    b.HasOne("ERPProject.Entity.Poco.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_User");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Company", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Invoices");

                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Offer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Product", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("RequestDetails");

                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Request", b =>
                {
                    b.Navigation("RequestDetails");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.Stock", b =>
                {
                    b.Navigation("StockDetails");
                });

            modelBuilder.Entity("ERPProject.Entity.Poco.User", b =>
                {
                    b.Navigation("Requests");

                    b.Navigation("StockDetailDeliverers");

                    b.Navigation("StockDetailRecievers");
                });
#pragma warning restore 612, 618
        }
    }
}
