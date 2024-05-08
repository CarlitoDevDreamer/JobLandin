﻿// <auto-generated />
using System;
using JobLandin.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobLandin.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240508150224_CompaniesDBCOntextII")]
    partial class CompaniesDBCOntextII
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobLandin.Domain.Entities.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Logo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            CompanyName = "Google",
                            Description = "Google is a multinational technology company that specializes in Internet-related services and products, which include online advertising technologies, a search engine, cloud computing, software, and hardware.",
                            Industry = "Technology",
                            Location = "Lagos",
                            Logo = new byte[] { 103, 111, 111, 103, 108, 101, 95, 108, 111, 103, 111 },
                            Size = 1000,
                            Website = "https://www.google.com"
                        },
                        new
                        {
                            CompanyId = 2,
                            CompanyName = "Facebook",
                            Description = "Facebook is an American online social media and social networking service company based in Menlo Park, California.",
                            Industry = "Technology",
                            Location = "Abuja",
                            Logo = new byte[] { 102, 97, 99, 101, 98, 111, 111, 107, 95, 108, 111, 103, 111 },
                            Size = 500,
                            Website = "https://www.facebook.com"
                        },
                        new
                        {
                            CompanyId = 3,
                            CompanyName = "Microsoft",
                            Description = "Microsoft Corporation is an American multinational technology company with headquarters in Redmond, Washington.",
                            Industry = "Technology",
                            Location = "Port Harcourt",
                            Logo = new byte[] { 109, 105, 99, 114, 111, 115, 111, 102, 116, 95, 108, 111, 103, 111 },
                            Size = 2000,
                            Website = "https://www.microsoft.com"
                        });
                });

            modelBuilder.Entity("JobLandin.Domain.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ApplicationMethod")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationDetails = "https://www.google.com/careers/",
                            ApplicationMethod = 0,
                            CompanyId = 1,
                            CreatedAt = new DateTime(2024, 5, 8, 16, 2, 23, 910, DateTimeKind.Local).AddTicks(955),
                            Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            Location = "Lagos",
                            Salary = 2000m,
                            Title = "Software Developer"
                        },
                        new
                        {
                            Id = 2,
                            ApplicationDetails = "data@email.com",
                            ApplicationMethod = 1,
                            CompanyId = 3,
                            CreatedAt = new DateTime(2024, 5, 8, 16, 2, 23, 910, DateTimeKind.Local).AddTicks(1010),
                            Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            Location = "Abuja",
                            Salary = 1500m,
                            Title = "Data Analyst"
                        },
                        new
                        {
                            Id = 3,
                            ApplicationDetails = "08012345678",
                            ApplicationMethod = 2,
                            CompanyId = 2,
                            CreatedAt = new DateTime(2024, 5, 8, 16, 2, 23, 910, DateTimeKind.Local).AddTicks(1014),
                            Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            Location = "Port Harcourt",
                            Salary = 2500m,
                            Title = "Product Manager"
                        });
                });

            modelBuilder.Entity("JobLandin.Domain.Entities.Job", b =>
                {
                    b.HasOne("JobLandin.Domain.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}
