using Microsoft.EntityFrameworkCore.Migrations;

namespace project_hospital_admin.Migrations
{
    public partial class FinishedAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppointmentTime",
                table: "Appointments",
                newName: "Doctor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Doctor",
                table: "Appointments",
                newName: "AppointmentTime");
        }
    }
}
