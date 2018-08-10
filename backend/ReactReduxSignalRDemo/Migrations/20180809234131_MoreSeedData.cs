using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactReduxSignalRDemo.Migrations
{
    public partial class MoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Username" },
                values: new object[] { 2, "pat" });

            migrationBuilder.InsertData(
                table: "Stats",
                columns: new[] { "StatsId", "Deaths", "Kills", "Losses", "UserId", "Wins" },
                values: new object[] { 2, 265, 1086, 58, 2, 252 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "StatsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
