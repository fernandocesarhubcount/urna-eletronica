﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

namespace api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220201002823_CreatingTables")]
    partial class CreatingTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("api.Models.Candidate", b =>
                {
                    b.Property<int>("SubTitle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ViceFullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SubTitle");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("api.Models.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CandidateSubTitle")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CandidateSubTitle");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("api.Models.Vote", b =>
                {
                    b.HasOne("api.Models.Candidate", null)
                        .WithMany("Votes")
                        .HasForeignKey("CandidateSubTitle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.Candidate", b =>
                {
                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}