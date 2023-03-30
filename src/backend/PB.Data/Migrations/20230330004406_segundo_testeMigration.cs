using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PB.Data.Migrations
{
    /// <inheritdoc />
    public partial class segundo_testeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollowers",
                table: "UserFollowers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserFollowers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollowers",
                table: "UserFollowers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowers_UserId",
                table: "UserFollowers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollowers",
                table: "UserFollowers");

            migrationBuilder.DropIndex(
                name: "IX_UserFollowers_UserId",
                table: "UserFollowers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserFollowers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollowers",
                table: "UserFollowers",
                columns: new[] { "UserId", "FollowerId" });
        }
    }
}
