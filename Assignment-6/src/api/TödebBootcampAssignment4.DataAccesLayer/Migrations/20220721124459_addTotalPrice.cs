using Microsoft.EntityFrameworkCore.Migrations;

namespace TödebBootcampAssignment4.DataAccesLayer.Migrations
{
    public partial class addTotalPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "Rezervations",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Rezervations");
        }
    }
}
