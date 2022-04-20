using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soulgram.AccountManage.Persistence.Migrations
{
    public partial class AddCreationDateToUserPictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HobbyImage_Hobbies_HobbyId",
                table: "HobbyImage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileImage_UserInfos_UserInfoUserId",
                table: "ProfileImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileImage",
                table: "ProfileImage");

            migrationBuilder.DropIndex(
                name: "IX_ProfileImage_UserInfoUserId",
                table: "ProfileImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HobbyImage",
                table: "HobbyImage");

            migrationBuilder.DropColumn(
                name: "UserInfoUserId",
                table: "ProfileImage");

            migrationBuilder.RenameTable(
                name: "ProfileImage",
                newName: "ProfileImages");

            migrationBuilder.RenameTable(
                name: "HobbyImage",
                newName: "HobbyImages");

            migrationBuilder.RenameIndex(
                name: "IX_HobbyImage_HobbyId",
                table: "HobbyImages",
                newName: "IX_HobbyImages_HobbyId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProfileImages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProfileImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileImages",
                table: "ProfileImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HobbyImages",
                table: "HobbyImages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileImages_UserId",
                table: "ProfileImages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HobbyImages_Hobbies_HobbyId",
                table: "HobbyImages",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileImages_UserInfos_UserId",
                table: "ProfileImages",
                column: "UserId",
                principalTable: "UserInfos",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HobbyImages_Hobbies_HobbyId",
                table: "HobbyImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileImages_UserInfos_UserId",
                table: "ProfileImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileImages",
                table: "ProfileImages");

            migrationBuilder.DropIndex(
                name: "IX_ProfileImages_UserId",
                table: "ProfileImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HobbyImages",
                table: "HobbyImages");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProfileImages");

            migrationBuilder.RenameTable(
                name: "ProfileImages",
                newName: "ProfileImage");

            migrationBuilder.RenameTable(
                name: "HobbyImages",
                newName: "HobbyImage");

            migrationBuilder.RenameIndex(
                name: "IX_HobbyImages_HobbyId",
                table: "HobbyImage",
                newName: "IX_HobbyImage_HobbyId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProfileImage",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserInfoUserId",
                table: "ProfileImage",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileImage",
                table: "ProfileImage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HobbyImage",
                table: "HobbyImage",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileImage_UserInfoUserId",
                table: "ProfileImage",
                column: "UserInfoUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HobbyImage_Hobbies_HobbyId",
                table: "HobbyImage",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileImage_UserInfos_UserInfoUserId",
                table: "ProfileImage",
                column: "UserInfoUserId",
                principalTable: "UserInfos",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
