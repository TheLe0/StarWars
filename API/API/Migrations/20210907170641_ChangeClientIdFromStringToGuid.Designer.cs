﻿// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Migrations
{
    [DbContext(typeof(StarWarsContext))]
    [Migration("20210907170641_ChangeClientIdFromStringToGuid")]
    partial class ChangeClientIdFromStringToGuid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("API.Models.CreditCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CardHolderName")
                        .HasColumnType("text")
                        .HasColumnName("card_holder_name");

                    b.Property<string>("CardNumber")
                        .HasColumnType("text")
                        .HasColumnName("card_number");

                    b.Property<string>("CardVerificationValue")
                        .HasColumnType("text")
                        .HasColumnName("cvv");

                    b.Property<string>("ExpirationDate")
                        .HasColumnType("text")
                        .HasColumnName("exp_date");

                    b.HasKey("Id")
                        .HasName("pk_credit_cards");

                    b.ToTable("credit_cards", "store");
                });

            modelBuilder.Entity("API.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Image")
                        .HasColumnType("text")
                        .HasColumnName("thumbnail_hd");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<string>("RegisterDate")
                        .HasColumnType("text")
                        .HasColumnName("date");

                    b.Property<string>("Seller")
                        .HasColumnType("text")
                        .HasColumnName("seller");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text")
                        .HasColumnName("zipcode");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.ToTable("products", "store");
                });

            modelBuilder.Entity("API.Models.Purchase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Amount")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.Property<string>("CardNumber")
                        .HasColumnType("text")
                        .HasColumnName("card_number");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid")
                        .HasColumnName("client_id");

                    b.Property<string>("TransDate")
                        .HasColumnType("text")
                        .HasColumnName("date");

                    b.HasKey("Id")
                        .HasName("pk_purchases");

                    b.ToTable("purchases", "store");
                });

            modelBuilder.Entity("API.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<double>("AmountTotal")
                        .HasColumnType("double precision")
                        .HasColumnName("total_amount");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid")
                        .HasColumnName("client_id");

                    b.Property<string>("ClientName")
                        .HasColumnType("text")
                        .HasColumnName("client_name");

                    b.Property<Guid?>("CreditCardId")
                        .HasColumnType("uuid")
                        .HasColumnName("creditcardid");

                    b.HasKey("Id")
                        .HasName("pk_transactions");

                    b.HasIndex("CreditCardId")
                        .HasDatabaseName("ix_transactions_creditcardid");

                    b.ToTable("transactions", "store");
                });

            modelBuilder.Entity("API.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", "store");
                });

            modelBuilder.Entity("API.Models.Transaction", b =>
                {
                    b.HasOne("API.Models.CreditCard", "CreditCard")
                        .WithMany()
                        .HasForeignKey("CreditCardId")
                        .HasConstraintName("fk_transactions_credit_cards_creditcardid");

                    b.Navigation("CreditCard");
                });
#pragma warning restore 612, 618
        }
    }
}