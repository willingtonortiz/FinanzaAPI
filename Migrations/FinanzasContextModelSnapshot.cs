﻿// <auto-generated />
using System;
using FinanzasBE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FinanzasBE.Migrations
{
    [DbContext(typeof(FinanzasContext))]
    partial class FinanzasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FinanzasBE.Entities.Bank", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BusinessName")
                        .HasColumnType("text");

                    b.Property<string>("Ruc")
                        .HasColumnType("text");

                    b.Property<double>("TEADolares")
                        .HasColumnType("double precision");

                    b.Property<double>("TEASoles")
                        .HasColumnType("double precision");

                    b.HasKey("BankId");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("FinanzasBE.Entities.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int>("BillType")
                        .HasColumnType("integer");

                    b.Property<string>("Currency")
                        .HasColumnType("text");

                    b.Property<string>("DraweeRuc")
                        .HasColumnType("text");

                    b.Property<string>("DrawerRuc")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PymeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("BillId");

                    b.HasIndex("PymeId");

                    b.ToTable("Bills");

                    b.HasData(
                        new
                        {
                            BillId = 1,
                            Amount = 1000.0,
                            BillType = 1,
                            Currency = "SOLES",
                            DraweeRuc = "20123456789",
                            DrawerRuc = "20123456789",
                            EndDate = new DateTime(2019, 10, 22, 9, 46, 38, 492, DateTimeKind.Local).AddTicks(74),
                            PymeId = 1,
                            StartDate = new DateTime(2019, 10, 22, 9, 46, 38, 490, DateTimeKind.Local).AddTicks(7249)
                        },
                        new
                        {
                            BillId = 2,
                            Amount = 2000.0,
                            BillType = 2,
                            Currency = "DOLARES",
                            DraweeRuc = "20123456789",
                            DrawerRuc = "20123456789",
                            EndDate = new DateTime(2019, 10, 22, 9, 46, 38, 492, DateTimeKind.Local).AddTicks(1162),
                            PymeId = 1,
                            StartDate = new DateTime(2019, 10, 22, 9, 46, 38, 492, DateTimeKind.Local).AddTicks(1141)
                        },
                        new
                        {
                            BillId = 3,
                            Amount = 3000.0,
                            BillType = 3,
                            Currency = "SOLES",
                            DraweeRuc = "20123456789",
                            DrawerRuc = "20123456789",
                            EndDate = new DateTime(2019, 10, 22, 9, 46, 38, 492, DateTimeKind.Local).AddTicks(1190),
                            PymeId = 1,
                            StartDate = new DateTime(2019, 10, 22, 9, 46, 38, 492, DateTimeKind.Local).AddTicks(1188)
                        });
                });

            modelBuilder.Entity("FinanzasBE.Entities.Cost", b =>
                {
                    b.Property<int>("CostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CostType")
                        .HasColumnType("text");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.HasKey("CostId");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("FinanzasBE.Entities.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BillId")
                        .HasColumnType("integer");

                    b.Property<double>("DeliveredValue")
                        .HasColumnType("double precision");

                    b.Property<int>("DiscountDays")
                        .HasColumnType("integer");

                    b.Property<int>("DiscountPoolId")
                        .HasColumnType("integer");

                    b.Property<double>("DiscountRate")
                        .HasColumnType("double precision");

                    b.Property<double>("FinalCost")
                        .HasColumnType("double precision");

                    b.Property<double>("InitialCost")
                        .HasColumnType("double precision");

                    b.Property<double>("NetValue")
                        .HasColumnType("double precision");

                    b.Property<double>("ReceivedValue")
                        .HasColumnType("double precision");

                    b.Property<double>("Retention")
                        .HasColumnType("double precision");

                    b.Property<double>("Tcea")
                        .HasColumnType("double precision");

                    b.Property<double>("Tep")
                        .HasColumnType("double precision");

                    b.HasKey("DiscountId");

                    b.HasIndex("BillId")
                        .IsUnique();

                    b.HasIndex("DiscountPoolId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("FinanzasBE.Entities.DiscountCost", b =>
                {
                    b.Property<int>("DiscountId")
                        .HasColumnType("integer");

                    b.Property<int>("CostId")
                        .HasColumnType("integer");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int>("DiscountCostId")
                        .HasColumnType("integer");

                    b.Property<string>("ValueType")
                        .HasColumnType("text");

                    b.HasKey("DiscountId", "CostId");

                    b.HasAlternateKey("DiscountCostId");

                    b.HasIndex("CostId");

                    b.ToTable("DiscountCosts");
                });

            modelBuilder.Entity("FinanzasBE.Entities.DiscountPool", b =>
                {
                    b.Property<int>("DiscountPoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BankId")
                        .HasColumnType("integer");

                    b.Property<double>("DeliveredValue")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("DiscountDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PymeId")
                        .HasColumnType("integer");

                    b.Property<double>("ReceivedValue")
                        .HasColumnType("double precision");

                    b.Property<double>("TCEA")
                        .HasColumnType("double precision");

                    b.HasKey("DiscountPoolId");

                    b.HasIndex("BankId");

                    b.HasIndex("PymeId");

                    b.ToTable("DiscountPools");
                });

            modelBuilder.Entity("FinanzasBE.Entities.Pyme", b =>
                {
                    b.Property<int>("PymeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("BusinessName")
                        .HasColumnType("text");

                    b.Property<string>("Ruc")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("PymeId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Pymes");

                    b.HasData(
                        new
                        {
                            PymeId = 1,
                            Address = "no address",
                            BusinessName = "PYME SAC",
                            Ruc = "20123456789",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("FinanzasBE.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Password = "20123456789",
                            Role = "USER",
                            Username = "20123456789"
                        });
                });

            modelBuilder.Entity("FinanzasBE.Entities.Bill", b =>
                {
                    b.HasOne("FinanzasBE.Entities.Pyme", "Pyme")
                        .WithMany("Bills")
                        .HasForeignKey("PymeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinanzasBE.Entities.Discount", b =>
                {
                    b.HasOne("FinanzasBE.Entities.Bill", "Bill")
                        .WithOne("Discount")
                        .HasForeignKey("FinanzasBE.Entities.Discount", "BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanzasBE.Entities.DiscountPool", "DiscountPool")
                        .WithMany("Discounts")
                        .HasForeignKey("DiscountPoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinanzasBE.Entities.DiscountCost", b =>
                {
                    b.HasOne("FinanzasBE.Entities.Cost", "Cost")
                        .WithMany("DiscountCosts")
                        .HasForeignKey("CostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanzasBE.Entities.Discount", "Discount")
                        .WithMany("DiscountCosts")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinanzasBE.Entities.DiscountPool", b =>
                {
                    b.HasOne("FinanzasBE.Entities.Bank", "Bank")
                        .WithMany("DiscountPools")
                        .HasForeignKey("BankId");

                    b.HasOne("FinanzasBE.Entities.Pyme", "Pyme")
                        .WithMany("DiscountPools")
                        .HasForeignKey("PymeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinanzasBE.Entities.Pyme", b =>
                {
                    b.HasOne("FinanzasBE.Entities.User", "User")
                        .WithOne("Pyme")
                        .HasForeignKey("FinanzasBE.Entities.Pyme", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
