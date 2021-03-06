// <auto-generated />
using System;
using AzureFunctionChartCalc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AzureFunctionChartCalc.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20220623200359_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AzureFunctionChartCalc.Models.Album", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AlbumCoverImageURL")
                        .HasColumnType("longtext");

                    b.Property<int>("AmountOfRatings")
                        .HasColumnType("int");

                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<double>("AverageRating")
                        .HasColumnType("double");

                    b.Property<string>("Descriptors")
                        .HasColumnType("longtext");

                    b.Property<string>("Genres")
                        .HasColumnType("longtext");

                    b.Property<string>("Languages")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("ReleaseDate")
                        .HasColumnType("int");

                    b.Property<string>("Types")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("ArtistId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("AzureFunctionChartCalc.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("AzureFunctionChartCalc.Models.Rating", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("AlbumID")
                        .HasColumnType("int");

                    b.Property<double>("RatingOutOfTen")
                        .HasColumnType("double");

                    b.HasKey("ID");

                    b.HasIndex("AlbumID");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("AzureFunctionChartCalc.Models.Album", b =>
                {
                    b.HasOne("AzureFunctionChartCalc.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("AzureFunctionChartCalc.Models.Rating", b =>
                {
                    b.HasOne("AzureFunctionChartCalc.Models.Album", null)
                        .WithMany("Ratings")
                        .HasForeignKey("AlbumID");
                });

            modelBuilder.Entity("AzureFunctionChartCalc.Models.Album", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
