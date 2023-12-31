﻿// <auto-generated />
using Kodlama.io.Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20230705101018_init1")]
    partial class init1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.PLTechnology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("ProgramingLanguageId")
                        .HasColumnType("int")
                        .HasColumnName("ProgramingLanguageId");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("ProgramingLanguageId");

                    b.ToTable("PLTechnologies", (string)null);
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProgramingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("ProgramingLanguage", (string)null);
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.PLTechnology", b =>
                {
                    b.HasOne("Kodlama.io.Devs.Domain.Entities.ProgramingLanguage", "ProgramingLanguage")
                        .WithMany("PLTechnologies")
                        .HasForeignKey("ProgramingLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramingLanguage");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProgramingLanguage", b =>
                {
                    b.Navigation("PLTechnologies");
                });
#pragma warning restore 612, 618
        }
    }
}
