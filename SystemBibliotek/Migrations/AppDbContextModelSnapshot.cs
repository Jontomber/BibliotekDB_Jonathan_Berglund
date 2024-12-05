﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SystemBibliotek.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SystemBibliotek.Models.Aurthor", b =>
                {
                    b.Property<int>("AurthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AurthorID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AurthorID");

                    b.ToTable("Aurthors");
                });

            modelBuilder.Entity("SystemBibliotek.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"));

                    b.Property<DateOnly>("PublishDate")
                        .HasColumnType("date");

                    b.Property<bool>("ReadyLoan")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("SystemBibliotek.Models.BookAurthor", b =>
                {
                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("AurthorID")
                        .HasColumnType("int");

                    b.Property<int>("BookAurthorID")
                        .HasColumnType("int");

                    b.HasKey("BookID", "AurthorID");

                    b.HasIndex("AurthorID");

                    b.ToTable("BookAurthors");
                });

            modelBuilder.Entity("SystemBibliotek.Models.Loan", b =>
                {
                    b.Property<int>("LoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanID"));

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Returned")
                        .HasColumnType("bit");

                    b.Property<string>("Signature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoanID");

                    b.HasIndex("BookID");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("SystemBibliotek.Models.BookAurthor", b =>
                {
                    b.HasOne("SystemBibliotek.Models.Aurthor", "Aurthor")
                        .WithMany("BookAurthors")
                        .HasForeignKey("AurthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SystemBibliotek.Models.Book", "Book")
                        .WithMany("BookAurthors")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aurthor");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("SystemBibliotek.Models.Loan", b =>
                {
                    b.HasOne("SystemBibliotek.Models.Book", "Book")
                        .WithMany("Loans")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("SystemBibliotek.Models.Aurthor", b =>
                {
                    b.Navigation("BookAurthors");
                });

            modelBuilder.Entity("SystemBibliotek.Models.Book", b =>
                {
                    b.Navigation("BookAurthors");

                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}
