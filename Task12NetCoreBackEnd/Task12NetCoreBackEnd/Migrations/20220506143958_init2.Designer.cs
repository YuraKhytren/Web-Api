﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task12NetCoreBackEnd.DataBase;

#nullable disable

namespace Task12NetCoreBackEnd.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220506143958_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Task12NetCoreBackEnd.Models.FinanceTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Income")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FinanceTypes");
                });

            modelBuilder.Entity("Task12NetCoreBackEnd.Models.MoneyOperationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FinanceTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FinanceTypeId");

                    b.ToTable("MoneyOperations");
                });

            modelBuilder.Entity("Task12NetCoreBackEnd.Models.MoneyOperationModel", b =>
                {
                    b.HasOne("Task12NetCoreBackEnd.Models.FinanceTypeModel", "FinanceType")
                        .WithMany("MoneyOperations")
                        .HasForeignKey("FinanceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinanceType");
                });

            modelBuilder.Entity("Task12NetCoreBackEnd.Models.FinanceTypeModel", b =>
                {
                    b.Navigation("MoneyOperations");
                });
#pragma warning restore 612, 618
        }
    }
}
