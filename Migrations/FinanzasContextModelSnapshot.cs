﻿// <auto-generated />
using System;
using FinanzasBE.Data;
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

                    b.Property<int>("CurrencyCode")
                        .HasColumnType("integer");

                    b.Property<string>("DraweeRuc")
                        .HasColumnType("text");

                    b.Property<string>("DrawerRuc")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PaymentPlace")
                        .HasColumnType("text");

                    b.Property<int>("PymeId")
                        .HasColumnType("integer");

                    b.Property<string>("SignPlace")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("BillId");

                    b.HasIndex("PymeId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("FinanzasBE.Entities.Cost", b =>
                {
                    b.Property<int>("CostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int>("CostType")
                        .HasColumnType("integer");

                    b.Property<int>("CurrencyCode")
                        .HasColumnType("integer");

                    b.Property<int>("DiscountId")
                        .HasColumnType("integer");

                    b.Property<int>("PaymentType")
                        .HasColumnType("integer");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.HasKey("CostId");

                    b.HasIndex("DiscountId");

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

            modelBuilder.Entity("FinanzasBE.Entities.DiscountPool", b =>
                {
                    b.Property<int>("DiscountPoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BankId")
                        .HasColumnType("integer");

                    b.Property<int>("CurrencyCode")
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
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("BusinessName")
                        .HasColumnType("text");

                    b.Property<string>("Ruc")
                        .HasColumnType("text");

                    b.HasKey("PymeId");

                    b.ToTable("Pymes");
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
                });

            modelBuilder.Entity("FinanzasBE.Entities.Bill", b =>
                {
                    b.HasOne("FinanzasBE.Entities.Pyme", "Pyme")
                        .WithMany("Bills")
                        .HasForeignKey("PymeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinanzasBE.Entities.Cost", b =>
                {
                    b.HasOne("FinanzasBE.Entities.Discount", "Discount")
                        .WithMany("Costs")
                        .HasForeignKey("DiscountId")
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
                        .HasForeignKey("FinanzasBE.Entities.Pyme", "PymeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
