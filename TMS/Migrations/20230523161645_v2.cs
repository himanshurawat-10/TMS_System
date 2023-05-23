using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_userUId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "userUId",
                table: "Requests",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_userUId",
                table: "Requests",
                newName: "IX_Requests_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_UserId",
                table: "Requests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_UserId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Requests",
                newName: "userUId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                newName: "IX_Requests_userUId");

            migrationBuilder.AddColumn<int>(
                name: "UId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_userUId",
                table: "Requests",
                column: "userUId",
                principalTable: "Users",
                principalColumn: "UId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
