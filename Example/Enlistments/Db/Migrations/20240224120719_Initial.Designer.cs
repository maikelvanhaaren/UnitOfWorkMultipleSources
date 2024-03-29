﻿// <auto-generated />
using System;
using Example.Enlistments.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnitOfWorkMultipleSources.Db;

#nullable disable

namespace UnitOfWorkMultipleSources.Db.Migrations
{
    [DbContext(typeof(ExampleDbContext))]
    [Migration("20240224120719_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("UnitOfWorkMultipleSources.Account", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ActivationCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Email");

                    b.ToTable("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
