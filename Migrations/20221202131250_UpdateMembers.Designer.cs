﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace projetalexmargo.Migrations
{
    [DbContext(typeof(ENSCContext))]
    [Migration("20221202131250_UpdateMembers")]
    partial class UpdateMembers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("ENSC.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Visibility")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ENSC.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("NbMembers")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PresidentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PresidentId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ENSC.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdGroup")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdStudent")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("ENSC.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAdress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Promo")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ENSC.Event", b =>
                {
                    b.HasOne("ENSC.Group", null)
                        .WithMany("Events")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("ENSC.Group", b =>
                {
                    b.HasOne("ENSC.Student", "President")
                        .WithMany("Groups")
                        .HasForeignKey("PresidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("President");
                });

            modelBuilder.Entity("ENSC.Group", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("ENSC.Student", b =>
                {
                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}
