﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestGuruApi.DataService.Data;

#nullable disable

namespace TestGuruApi.DataService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("TestId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Points")
                        .HasColumnType("real");

                    b.Property<string>("QuestionType")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("TestId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TestId");

                    b.ToTable("Question");

                    b.HasDiscriminator<string>("QuestionType").HasValue("Question");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Duration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("MinimumPassingScore")
                        .HasColumnType("real");

                    b.Property<DateTime?>("ScheduledClosingTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ScheduledPublishTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid?>("TestCollectionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("TotalQuestionsCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("TestCollectionId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.TestCollection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("TestCollections");
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.MatchingQuestion", b =>
                {
                    b.HasBaseType("TestGuruApi.Entities.DbSet.Question");

                    b.Property<string[]>("LeftColumn")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string[]>("RightColumn")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.HasDiscriminator().HasValue("Matching");
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.MultipleChoiceQuestion", b =>
                {
                    b.HasBaseType("TestGuruApi.Entities.DbSet.Question");

                    b.HasDiscriminator().HasValue("MultipleChoice");
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.SingleChoiceQuestion", b =>
                {
                    b.HasBaseType("TestGuruApi.Entities.DbSet.Question");

                    b.HasDiscriminator().HasValue("SingleChoice");
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.Answer", b =>
                {
                    b.HasOne("TestGuruApi.Entities.DbSet.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.Category", b =>
                {
                    b.HasOne("TestGuruApi.Entities.DbSet.Test", "Test")
                        .WithMany("Categories")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.Question", b =>
                {
                    b.HasOne("TestGuruApi.Entities.DbSet.Category", "Category")
                        .WithMany("Questions")
                        .HasForeignKey("CategoryId");

                    b.HasOne("TestGuruApi.Entities.DbSet.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.Test", b =>
                {
                    b.HasOne("TestGuruApi.Entities.DbSet.TestCollection", "TestCollection")
                        .WithMany("Tests")
                        .HasForeignKey("TestCollectionId");

                    b.Navigation("TestCollection");
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.Category", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.Test", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("TestGuruApi.Entities.DbSet.TestCollection", b =>
                {
                    b.Navigation("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}
