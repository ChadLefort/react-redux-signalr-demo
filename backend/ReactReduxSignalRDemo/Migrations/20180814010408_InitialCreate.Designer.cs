﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Migrations
{
    [DbContext(typeof(OperatorsContext))]
    [Migration("20180814010408_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReactReduxSignalRDemo.Models.Operator", b =>
                {
                    b.Property<int>("OperatorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Icon");

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.HasKey("OperatorId");

                    b.ToTable("Operators");

                    b.HasData(
                        new { OperatorId = 1, Icon = "sledge.svg", Name = "Sledge", Type = "Attacker" },
                        new { OperatorId = 2, Icon = "thatcher.svg", Name = "Thatcher", Type = "Attacker" },
                        new { OperatorId = 3, Icon = "ash.svg", Name = "Ash", Type = "Attacker" },
                        new { OperatorId = 4, Icon = "thermite.svg", Name = "Thermite", Type = "Attacker" },
                        new { OperatorId = 5, Icon = "twitch.svg", Name = "Twitch", Type = "Attacker" },
                        new { OperatorId = 6, Icon = "montagne.svg", Name = "Montagne", Type = "Attacker" },
                        new { OperatorId = 7, Icon = "glaz.svg", Name = "Glaz", Type = "Attacker" },
                        new { OperatorId = 8, Icon = "fuze.svg", Name = "Fuze", Type = "Attacker" },
                        new { OperatorId = 9, Icon = "blitz.svg", Name = "Blitz", Type = "Attacker" },
                        new { OperatorId = 10, Icon = "iq.svg", Name = "IQ", Type = "Attacker" },
                        new { OperatorId = 11, Icon = "buck.svg", Name = "Buck", Type = "Attacker" },
                        new { OperatorId = 12, Icon = "blackbeard.svg", Name = "Blackbeard", Type = "Attacker" },
                        new { OperatorId = 13, Icon = "capitão.svg", Name = "Capitão", Type = "Attacker" },
                        new { OperatorId = 14, Icon = "hibana.svg", Name = "Hibana", Type = "Attacker" },
                        new { OperatorId = 15, Icon = "jackal.svg", Name = "Jackal", Type = "Attacker" },
                        new { OperatorId = 16, Icon = "ying.svg", Name = "Ying", Type = "Attacker" },
                        new { OperatorId = 17, Icon = "zofia.svg", Name = "Zofia", Type = "Attacker" },
                        new { OperatorId = 18, Icon = "dokkaebi.svg", Name = "Dokkaebi", Type = "Attacker" },
                        new { OperatorId = 19, Icon = "lion.svg", Name = "Lion", Type = "Attacker" },
                        new { OperatorId = 20, Icon = "finka.svg", Name = "Finka", Type = "Attacker" },
                        new { OperatorId = 21, Icon = "recruit.svg", Name = "Recruit", Type = "Attacker" },
                        new { OperatorId = 22, Icon = "smoke.svg", Name = "Smoke", Type = "Defender" },
                        new { OperatorId = 23, Icon = "mute.svg", Name = "Mute", Type = "Defender" },
                        new { OperatorId = 24, Icon = "castle.svg", Name = "Castle", Type = "Defender" },
                        new { OperatorId = 25, Icon = "pulse.svg", Name = "Pulse", Type = "Defender" },
                        new { OperatorId = 26, Icon = "doc.svg", Name = "Doc", Type = "Defender" },
                        new { OperatorId = 27, Icon = "rook.svg", Name = "Rook", Type = "Defender" },
                        new { OperatorId = 28, Icon = "kapkan.svg", Name = "Kapkan", Type = "Defender" },
                        new { OperatorId = 29, Icon = "tachanka.svg", Name = "Tachanka", Type = "Defender" },
                        new { OperatorId = 30, Icon = "jäger.svg", Name = "Jäger", Type = "Defender" },
                        new { OperatorId = 31, Icon = "bandit.svg", Name = "Bandit", Type = "Defender" },
                        new { OperatorId = 32, Icon = "frost.svg", Name = "Frost", Type = "Defender" },
                        new { OperatorId = 33, Icon = "valkyrie.svg", Name = "Valkyrie", Type = "Defender" },
                        new { OperatorId = 34, Icon = "caveira.svg", Name = "Caveira", Type = "Defender" },
                        new { OperatorId = 35, Icon = "echo.svg", Name = "Echo", Type = "Defender" },
                        new { OperatorId = 36, Icon = "mira.svg", Name = "Mira", Type = "Defender" },
                        new { OperatorId = 37, Icon = "lesion.svg", Name = "Lesion", Type = "Defender" },
                        new { OperatorId = 38, Icon = "ela.svg", Name = "Ela", Type = "Defender" },
                        new { OperatorId = 39, Icon = "vigil.svg", Name = "Vigil", Type = "Defender" },
                        new { OperatorId = 40, Icon = "maestro.svg", Name = "Maestro", Type = "Defender" },
                        new { OperatorId = 41, Icon = "alibi.svg", Name = "Alibi", Type = "Defender" },
                        new { OperatorId = 42, Icon = "recruit.svg", Name = "Recruit", Type = "Defender" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
