using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soulgram.AccountManage.Persistence.Migrations
{
    public partial class AddCountOfUsageToHobby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountOfUsage",
                table: "Hobbies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfUsage",
                table: "Hobbies");
        }
    }
}
