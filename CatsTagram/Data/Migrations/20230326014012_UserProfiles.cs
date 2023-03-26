using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatsTagram.Data.Migrations
{
    public partial class UserProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Profile_Biography",
                table: "AspNetUsers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Profile_Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Profile_IsPrivate",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Profile_Name",
                table: "AspNetUsers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile_PhotoUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile_WebSite",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profile_Biography",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_IsPrivate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_PhotoUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_WebSite",
                table: "AspNetUsers");
        }
    }
}
