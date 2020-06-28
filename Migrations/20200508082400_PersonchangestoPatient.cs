using Microsoft.EntityFrameworkCore.Migrations;

namespace EpidemicTrackerApplication.Migrations
{
    public partial class PersonchangestoPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonName",
                table: "Patients",
                newName: "PatientName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatientName",
                table: "Patients",
                newName: "PersonName");
        }
    }
}
