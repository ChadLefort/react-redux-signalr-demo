using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactReduxSignalRDemo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    OperatorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.OperatorId);
                });

            migrationBuilder.InsertData(
                table: "Operators",
                columns: new[] { "OperatorId", "Icon", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "sledge.svg", "Sledge", "Attacker" },
                    { 24, "castle.svg", "Castle", "Defender" },
                    { 25, "pulse.svg", "Pulse", "Defender" },
                    { 26, "doc.svg", "Doc", "Defender" },
                    { 27, "rook.svg", "Rook", "Defender" },
                    { 28, "kapkan.svg", "Kapkan", "Defender" },
                    { 29, "tachanka.svg", "Tachanka", "Defender" },
                    { 30, "jäger.svg", "Jäger", "Defender" },
                    { 31, "bandit.svg", "Bandit", "Defender" },
                    { 32, "frost.svg", "Frost", "Defender" },
                    { 33, "valkyrie.svg", "Valkyrie", "Defender" },
                    { 34, "caveira.svg", "Caveira", "Defender" },
                    { 35, "echo.svg", "Echo", "Defender" },
                    { 36, "mira.svg", "Mira", "Defender" },
                    { 37, "lesion.svg", "Lesion", "Defender" },
                    { 38, "ela.svg", "Ela", "Defender" },
                    { 39, "vigil.svg", "Vigil", "Defender" },
                    { 40, "maestro.svg", "Maestro", "Defender" },
                    { 23, "mute.svg", "Mute", "Defender" },
                    { 22, "smoke.svg", "Smoke", "Defender" },
                    { 21, "recruit.svg", "Recruit", "Attacker" },
                    { 20, "finka.svg", "Finka", "Attacker" },
                    { 2, "thatcher.svg", "Thatcher", "Attacker" },
                    { 3, "ash.svg", "Ash", "Attacker" },
                    { 4, "thermite.svg", "Thermite", "Attacker" },
                    { 5, "twitch.svg", "Twitch", "Attacker" },
                    { 6, "montagne.svg", "Montagne", "Attacker" },
                    { 7, "glaz.svg", "Glaz", "Attacker" },
                    { 8, "fuze.svg", "Fuze", "Attacker" },
                    { 9, "blitz.svg", "Blitz", "Attacker" },
                    { 41, "alibi.svg", "Alibi", "Defender" },
                    { 10, "iq.svg", "IQ", "Attacker" },
                    { 12, "blackbeard.svg", "Blackbeard", "Attacker" },
                    { 13, "capitão.svg", "Capitão", "Attacker" },
                    { 14, "hibana.svg", "Hibana", "Attacker" },
                    { 15, "jackal.svg", "Jackal", "Attacker" },
                    { 16, "ying.svg", "Ying", "Attacker" },
                    { 17, "zofia.svg", "Zofia", "Attacker" },
                    { 18, "dokkaebi.svg", "Dokkaebi", "Attacker" },
                    { 19, "lion.svg", "Lion", "Attacker" },
                    { 11, "buck.svg", "Buck", "Attacker" },
                    { 42, "recruit.svg", "Recruit", "Defender" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operators");
        }
    }
}
