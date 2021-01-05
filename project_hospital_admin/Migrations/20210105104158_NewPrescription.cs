using Microsoft.EntityFrameworkCore.Migrations;

namespace project_hospital_admin.Migrations
{
    public partial class NewPrescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Diagnose",
                table: "Prescriptions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Medication",
                table: "Prescriptions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diagnose",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Medication",
                table: "Prescriptions");
        }
    }
}
