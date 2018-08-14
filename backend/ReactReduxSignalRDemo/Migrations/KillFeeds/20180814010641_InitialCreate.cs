using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactReduxSignalRDemo.Migrations.KillFeeds
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KillFeeds",
                columns: table => new
                {
                    KillFeedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KillFeeds", x => x.KillFeedId);
                });

            migrationBuilder.CreateTable(
                name: "KillFeedItems",
                columns: table => new
                {
                    KillFeedItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KillFeedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KillFeedItems", x => x.KillFeedItemId);
                    table.ForeignKey(
                        name: "FK_KillFeedItems_KillFeeds_KillFeedId",
                        column: x => x.KillFeedId,
                        principalTable: "KillFeeds",
                        principalColumn: "KillFeedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeathUsers",
                columns: table => new
                {
                    DeathUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KillFeedItemId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Operator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeathUsers", x => x.DeathUserId);
                    table.ForeignKey(
                        name: "FK_DeathUsers_KillFeedItems_KillFeedItemId",
                        column: x => x.KillFeedItemId,
                        principalTable: "KillFeedItems",
                        principalColumn: "KillFeedItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KillUsers",
                columns: table => new
                {
                    KillUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KillFeedItemId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Operator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KillUsers", x => x.KillUserId);
                    table.ForeignKey(
                        name: "FK_KillUsers_KillFeedItems_KillFeedItemId",
                        column: x => x.KillFeedItemId,
                        principalTable: "KillFeedItems",
                        principalColumn: "KillFeedItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "KillFeeds",
                columns: new[] { "KillFeedId", "MatchId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "KillFeedItems",
                columns: new[] { "KillFeedItemId", "KillFeedId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "KillFeedItems",
                columns: new[] { "KillFeedItemId", "KillFeedId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "DeathUsers",
                columns: new[] { "DeathUserId", "KillFeedItemId", "Operator", "Username" },
                values: new object[,]
                {
                    { 1, 1, "Mira", "Gully" },
                    { 2, 2, "Ash", "Chad" }
                });

            migrationBuilder.InsertData(
                table: "KillUsers",
                columns: new[] { "KillUserId", "KillFeedItemId", "Operator", "Username" },
                values: new object[,]
                {
                    { 1, 1, "Ash", "Chad" },
                    { 2, 2, "Mira", "Gully" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeathUsers_KillFeedItemId",
                table: "DeathUsers",
                column: "KillFeedItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KillFeedItems_KillFeedId",
                table: "KillFeedItems",
                column: "KillFeedId");

            migrationBuilder.CreateIndex(
                name: "IX_KillUsers_KillFeedItemId",
                table: "KillUsers",
                column: "KillFeedItemId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeathUsers");

            migrationBuilder.DropTable(
                name: "KillUsers");

            migrationBuilder.DropTable(
                name: "KillFeedItems");

            migrationBuilder.DropTable(
                name: "KillFeeds");
        }
    }
}
