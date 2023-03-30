using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PB.Data.Migrations
{
    /// <inheritdoc />
    public partial class TesteFollowers2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Users_FollowerId",
                table: "UserFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Users_FollowerId1",
                table: "UserFollowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollowers",
                table: "UserFollowers");

            migrationBuilder.DropIndex(
                name: "IX_UserFollowers_FollowerId",
                table: "UserFollowers");

            migrationBuilder.DropIndex(
                name: "IX_UserFollowers_FollowerId1",
                table: "UserFollowers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserFollowers");

            migrationBuilder.DropColumn(
                name: "FollowerId1",
                table: "UserFollowers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserFollowers",
                newName: "FollowedUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollowers",
                table: "UserFollowers",
                columns: new[] { "FollowerId", "FollowedUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowers_FollowedUserId",
                table: "UserFollowers",
                column: "FollowedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_Users_FollowedUserId",
                table: "UserFollowers",
                column: "FollowedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowers_Users_FollowerId",
                table: "UserFollowers",
                column: "FollowerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Users_FollowedUserId",
                table: "UserFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowers_Users_FollowerId",
                table: "UserFollowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollowers",
                table: "UserFollowers");

            migrationBuilder.DropIndex(
                name: "IX_UserFollowers_FollowedUserId",
                table: "UserFollowers");

            migrationBuilder.RenameColumn(
                name: "FollowedUserId",
                table: "UserFollowers",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserFollowers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FollowerId1",
                table: "UserFollowers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollowers",
                table: "UserFollowers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowers_FollowerId",
                table: "UserFollowers",
                column: "FollowerId");

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
    }
}
