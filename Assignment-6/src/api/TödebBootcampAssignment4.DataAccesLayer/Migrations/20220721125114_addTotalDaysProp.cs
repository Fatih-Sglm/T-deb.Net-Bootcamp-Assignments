using Microsoft.EntityFrameworkCore.Migrations;

namespace TödebBootcampAssignment4.DataAccesLayer.Migrations
{
    public partial class addTotalDaysProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TotalDays",
                table: "Rezervations",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDays",
                table: "Rezervations");
        }
    }
}
