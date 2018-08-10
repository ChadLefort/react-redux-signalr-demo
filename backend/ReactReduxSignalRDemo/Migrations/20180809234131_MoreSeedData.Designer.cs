﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Migrations
{
    [DbContext(typeof(R6StatsContext))]
    [Migration("20180809234131_MoreSeedData")]
    partial class MoreSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReactReduxSignalRDemo.Models.Stats", b =>
                {
                    b.Property<int>("StatsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Deaths");

                    b.Property<int>("Kills");

                    b.Property<int>("Losses");

                    b.Property<int>("UserId");

                    b.Property<int>("Wins");

                    b.HasKey("StatsId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Stats");

                    b.HasData(
                        new { StatsId = 1, Deaths = 640, Kills = 850, Losses = 124, UserId = 1, Wins = 131 },
                        new { StatsId = 2, Deaths = 265, Kills = 1086, Losses = 58, UserId = 2, Wins = 252 }
                    );
                });

            modelBuilder.Entity("ReactReduxSignalRDemo.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new { UserId = 1, Username = "chad" },
                        new { UserId = 2, Username = "pat" }
                    );
                });

            modelBuilder.Entity("ReactReduxSignalRDemo.Models.Stats", b =>
                {
                    b.HasOne("ReactReduxSignalRDemo.Models.User")
                        .WithOne("Stats")
                        .HasForeignKey("ReactReduxSignalRDemo.Models.Stats", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}