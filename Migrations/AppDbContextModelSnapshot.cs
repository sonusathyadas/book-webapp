using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using BookManager.Data;

namespace BookManager.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BookManager.Models.Book", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<string>("Author")
                    .HasColumnType("TEXT");

                b.Property<string>("CoverImageUrl")
                    .HasColumnType("TEXT");

                b.Property<string>("Genre")
                    .HasColumnType("TEXT");

                b.Property<string>("Language")
                    .HasColumnType("TEXT");

                b.Property<int>("NumberOfPages")
                    .HasColumnType("INTEGER");

                b.Property<string>("Title")
                    .HasColumnType("TEXT");

                b.HasKey("Id");

                b.ToTable("Books");
            });
        }
    }
}