using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soulgram.AccountManage.Persistence.Migrations
{
    public partial class AddFullnameToUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "UserInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "UserInfos");
        }
    }
}
