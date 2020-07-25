using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorsAgenda.Migrations
{
    public partial class UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_User_UserName",
                table: "Agenda");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_User_UserName",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserName",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_UserName",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_AgendasName_UserName",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Agenda");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Agenda",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                table: "User",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_UserId",
                table: "Agenda",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_AgendasName_UserId",
                table: "Agenda",
                columns: new[] { "AgendasName", "UserId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_User_UserId",
                table: "Agenda",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_User_UserId",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_User_UserName",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_UserId",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_AgendasName_UserId",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Agenda");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Agenda",
                type: "nvarchar(256)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_User_UserName",
                table: "User",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                table: "User",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_UserName",
                table: "Agenda",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_AgendasName_UserName",
                table: "Agenda",
                columns: new[] { "AgendasName", "UserName" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_User_UserName",
                table: "Agenda",
                column: "UserName",
                principalTable: "User",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
