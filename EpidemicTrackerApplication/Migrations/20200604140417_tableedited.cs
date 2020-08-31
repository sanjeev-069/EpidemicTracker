using Microsoft.EntityFrameworkCore.Migrations;

namespace EpidemicTrackerApplication.Migrations
{
    public partial class tableedited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentRecords_Diseases_Diseaseid",
                table: "TreatmentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentRecords_Hospitals_Hospitalid",
                table: "TreatmentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentRecords_Patients_PatientId",
                table: "TreatmentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentRecords_TreatmentDetails_Treatmentid",
                table: "TreatmentRecords");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecords_Diseases_Diseaseid",
                table: "TreatmentRecords",
                column: "Diseaseid",
                principalTable: "Diseases",
                principalColumn: "DiseaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecords_Hospitals_Hospitalid",
                table: "TreatmentRecords",
                column: "Hospitalid",
                principalTable: "Hospitals",
                principalColumn: "HospitalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecords_Patients_PatientId",
                table: "TreatmentRecords",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecords_TreatmentDetails_Treatmentid",
                table: "TreatmentRecords",
                column: "Treatmentid",
                principalTable: "TreatmentDetails",
                principalColumn: "TreatmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentRecords_Diseases_Diseaseid",
                table: "TreatmentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentRecords_Hospitals_Hospitalid",
                table: "TreatmentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentRecords_Patients_PatientId",
                table: "TreatmentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentRecords_TreatmentDetails_Treatmentid",
                table: "TreatmentRecords");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecords_Diseases_Diseaseid",
                table: "TreatmentRecords",
                column: "Diseaseid",
                principalTable: "Diseases",
                principalColumn: "DiseaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecords_Hospitals_Hospitalid",
                table: "TreatmentRecords",
                column: "Hospitalid",
                principalTable: "Hospitals",
                principalColumn: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecords_Patients_PatientId",
                table: "TreatmentRecords",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecords_TreatmentDetails_Treatmentid",
                table: "TreatmentRecords",
                column: "Treatmentid",
                principalTable: "TreatmentDetails",
                principalColumn: "TreatmentId");
        }
    }
}
