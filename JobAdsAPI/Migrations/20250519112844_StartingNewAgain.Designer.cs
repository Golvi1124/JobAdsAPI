﻿// <auto-generated />
using System;
using JobAdsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobAdsAPI.Migrations
{
    [DbContext(typeof(JobAdDbContext))]
    [Migration("20250519112844_StartingNewAgain")]
    partial class StartingNewAgain
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("JobAdOtherSkills", b =>
                {
                    b.Property<int>("JobAdId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OtherSkillId")
                        .HasColumnType("INTEGER");

                    b.HasKey("JobAdId", "OtherSkillId");

                    b.HasIndex("OtherSkillId");

                    b.ToTable("JobAdOtherSkills");
                });

            modelBuilder.Entity("JobAdsAPI.Models.ExpierienceLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ExpierienceLevels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Junior"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mid"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Senior"
                        });
                });

            modelBuilder.Entity("JobAdsAPI.Models.JobAd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ExpierienceLevelId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCSharpMentioned")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDotNetMentioned")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSQLMentioned")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("JobAdDescriptionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobTitle")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PublishedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WorkTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ExpierienceLevelId");

                    b.HasIndex("JobAdDescriptionId")
                        .IsUnique();

                    b.HasIndex("LocationId");

                    b.HasIndex("WorkTypeId");

                    b.ToTable("JobAds");
                });

            modelBuilder.Entity("JobAdsAPI.Models.JobAdDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmployerDescription")
                        .HasColumnType("TEXT");

                    b.Property<int>("JobAdId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("JobAdDescriptions");
                });

            modelBuilder.Entity("JobAdsAPI.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("JobAdsAPI.Models.OtherSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OtherSkills");
                });

            modelBuilder.Entity("JobAdsAPI.Models.WorkType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WorkTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Office"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hybrid"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Remote"
                        });
                });

            modelBuilder.Entity("JobAdOtherSkills", b =>
                {
                    b.HasOne("JobAdsAPI.Models.JobAd", null)
                        .WithMany()
                        .HasForeignKey("JobAdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobAdsAPI.Models.OtherSkill", null)
                        .WithMany()
                        .HasForeignKey("OtherSkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobAdsAPI.Models.JobAd", b =>
                {
                    b.HasOne("JobAdsAPI.Models.ExpierienceLevel", "ExpierienceLevel")
                        .WithMany()
                        .HasForeignKey("ExpierienceLevelId");

                    b.HasOne("JobAdsAPI.Models.JobAdDescription", "JobAdDescription")
                        .WithOne()
                        .HasForeignKey("JobAdsAPI.Models.JobAd", "JobAdDescriptionId");

                    b.HasOne("JobAdsAPI.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("JobAdsAPI.Models.WorkType", "WorkType")
                        .WithMany()
                        .HasForeignKey("WorkTypeId");

                    b.Navigation("ExpierienceLevel");

                    b.Navigation("JobAdDescription");

                    b.Navigation("Location");

                    b.Navigation("WorkType");
                });
#pragma warning restore 612, 618
        }
    }
}
