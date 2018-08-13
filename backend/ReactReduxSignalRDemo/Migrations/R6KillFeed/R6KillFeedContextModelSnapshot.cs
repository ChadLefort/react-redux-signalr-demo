﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Migrations.R6KillFeed
{
    [DbContext(typeof(R6KillFeedContext))]
    partial class R6KillFeedContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReactReduxSignalRDemo.Models.DeathUser", b =>
                {
                    b.Property<int>("DeathUserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KillFeedItemId");

                    b.Property<string>("Operator");

                    b.Property<string>("Username");

                    b.HasKey("DeathUserId");

                    b.HasIndex("KillFeedItemId")
                        .IsUnique();

                    b.ToTable("DeathUsers");

                    b.HasData(
                        new { DeathUserId = 1, KillFeedItemId = 1, Operator = "Mirror", Username = "Gully" },
                        new { DeathUserId = 2, KillFeedItemId = 2, Operator = "Ash", Username = "chad" }
                    );
                });

            modelBuilder.Entity("ReactReduxSignalRDemo.Models.KillFeed", b =>
                {
                    b.Property<int>("KillFeedId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MatchId");

                    b.Property<int>("UserId");

                    b.HasKey("KillFeedId");

                    b.ToTable("KillFeeds");

                    b.HasData(
                        new { KillFeedId = 1, MatchId = 1, UserId = 1 }
                    );
                });

            modelBuilder.Entity("ReactReduxSignalRDemo.Models.KillFeedItem", b =>
                {
                    b.Property<int>("KillFeedItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KillFeedId");

                    b.HasKey("KillFeedItemId");

                    b.HasIndex("KillFeedId");

                    b.ToTable("KillFeedItems");

                    b.HasData(
                        new { KillFeedItemId = 1, KillFeedId = 1 },
                        new { KillFeedItemId = 2, KillFeedId = 1 }
                    );
                });

            modelBuilder.Entity("ReactReduxSignalRDemo.Models.KillUser", b =>
                {
                    b.Property<int>("KillUserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KillFeedItemId");

                    b.Property<string>("Operator");

                    b.Property<string>("Username");

                    b.HasKey("KillUserId");

                    b.HasIndex("KillFeedItemId")
                        .IsUnique();

                    b.ToTable("KillUsers");

                    b.HasData(
                        new { KillUserId = 1, KillFeedItemId = 1, Operator = "Ash", Username = "chad" },
                        new { KillUserId = 2, KillFeedItemId = 2, Operator = "Mirror", Username = "Gully" }
                    );
                });

            modelBuilder.Entity("ReactReduxSignalRDemo.Models.DeathUser", b =>
                {
                    b.HasOne("ReactReduxSignalRDemo.Models.KillFeedItem")
                        .WithOne("Death")
                        .HasForeignKey("ReactReduxSignalRDemo.Models.DeathUser", "KillFeedItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReactReduxSignalRDemo.Models.KillFeedItem", b =>
                {
                    b.HasOne("ReactReduxSignalRDemo.Models.KillFeed")
                        .WithMany("KillFeedItems")
                        .HasForeignKey("KillFeedId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReactReduxSignalRDemo.Models.KillUser", b =>
                {
                    b.HasOne("ReactReduxSignalRDemo.Models.KillFeedItem")
                        .WithOne("Kill")
                        .HasForeignKey("ReactReduxSignalRDemo.Models.KillUser", "KillFeedItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
