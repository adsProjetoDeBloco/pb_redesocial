using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PB.Data.Migrations
{
    /// <inheritdoc />
    public partial class Teste_followers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Followers_FollowerId",
                table: "UserFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Users_UserId",
                table: "UserFollowers");

            migrationBuilder.DropTable(
                name: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_UserFollowers_UserId",
                table: "UserFollowers");

            migrationBuilder.AddColumn<int>(
                name: "FollowerId1",
                table: "UserFollowers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowers_FollowerId1",
                table: "UserFollowers",
                column: "FollowerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_Users_FollowerId",
                table: "UserFollowers",
                column: "FollowerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_Users_FollowerId1",
                table: "UserFollowers",
                column: "FollowerId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Users_FollowerId",
                table: "UserFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Users_FollowerId1",
                table: "UserFollowers");

            migrationBuilder.DropIndex(
                name: "IX_UserFollowers_FollowerId1",
                table: "UserFollowers");

            migrationBuilder.DropColumn(
                name: "FollowerId1",
                table: "UserFollowers");

            migrationBuilder.CreateTable(
                name: "Followers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowers_UserId",
                table: "UserFollowers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_Followers_FollowerId",
                table: "UserFollowers",
                column: "FollowerId",
                principalTable: "Followers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_Users_UserId",
                table: "UserFollowers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
