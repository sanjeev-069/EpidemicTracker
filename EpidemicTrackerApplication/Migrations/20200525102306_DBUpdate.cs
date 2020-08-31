using Microsoft.EntityFrameworkCore.Migrations;

namespace EpidemicTrackerApplication.Migrations
{
    public partial class DBUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalAddresses_Hospitals_Hospitalid",
                table: "HospitalAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Occupations_Patients_Patientid",
                table: "Occupations");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientAddresses_Patients_Patientid",
                table: "PatientAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Logins_Loginid",
                table: "Patients");

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

            migrationBuilder.DropForeignKey(
                name: "FK_UniqueIdTypes_Patients_Patientid",
                table: "UniqueIdTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAddresses_Occupations_Occupationid",
                table: "WorkAddresses");

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalAddresses_Hospitals_Hospitalid",
                table: "HospitalAddresses",
                column: "Hospitalid",
                principalTable: "Hospitals",
                principalColumn: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Occupations_Patients_Patientid",
                table: "Occupations",
                column: "Patientid",
                principalTable: "Patients",
                principalColumn: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAddresses_Patients_Patientid",
                table: "PatientAddresses",
                column: "Patientid",
                principalTable: "Patients",
                principalColumn: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Logins_Loginid",
                table: "Patients",
                column: "Loginid",
                principalTable: "Logins",
                principalColumn: "LoginId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UniqueIdTypes_Patients_Patientid",
                table: "UniqueIdTypes",
                column: "Patientid",
                principalTable: "Patients",
                principalColumn: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAddresses_Occupations_Occupationid",
                table: "WorkAddresses",
                column: "Occupationid",
                principalTable: "Occupations",
                principalColumn: "OccupationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalAddresses_Hospitals_Hospitalid",
                table: "HospitalAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Occupations_Patients_Patientid",
                table: "Occupations");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientAddresses_Patients_Patientid",
                table: "PatientAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Logins_Loginid",
                table: "Patients");

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

            migrationBuilder.DropForeignKey(
                name: "FK_UniqueIdTypes_Patients_Patientid",
                table: "UniqueIdTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAddresses_Occupations_Occupationid",
                table: "WorkAddresses");

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalAddresses_Hospitals_Hospitalid",
                table: "HospitalAddresses",
                column: "Hospitalid",
                principalTable: "Hospitals",
                principalColumn: "HospitalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Occupations_Patients_Patientid",
                table: "Occupations",
                column: "Patientid",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAddresses_Patients_Patientid",
                table: "PatientAddresses",
                column: "Patientid",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Logins_Loginid",
                table: "Patients",
                column: "Loginid",
                principalTable: "Logins",
                principalColumn: "LoginId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecords_Diseases_Diseaseid",
                table: "TreatmentRecords",
                column: "Diseaseid",
                principalTable: "Diseases",
                principalColumn: "DiseaseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecords_Hospitals_Hospitalid",
                table: "TreatmentRecords",
                column: "Hospitalid",
                principalTable: "Hospitals",
                principalColumn: "HospitalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecords_Patients_PatientId",
                table: "TreatmentRecords",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentRecords_TreatmentDetails_Treatmentid",
                table: "TreatmentRecords",
                column: "Treatmentid",
                principalTable: "TreatmentDetails",
                principalColumn: "TreatmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UniqueIdTypes_Patients_Patientid",
                table: "UniqueIdTypes",
                column: "Patientid",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAddresses_Occupations_Occupationid",
                table: "WorkAddresses",
                column: "Occupationid",
                principalTable: "Occupations",
                principalColumn: "OccupationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
