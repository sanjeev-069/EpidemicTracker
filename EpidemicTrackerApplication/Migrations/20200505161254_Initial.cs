using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EpidemicTrackerApplication.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    DiseaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseName = table.Column<string>(maxLength: 20, nullable: false),
                    DiseaseType = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.DiseaseId);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    HospitalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalName = table.Column<string>(maxLength: 20, nullable: false),
                    HospitalPhoneNumber = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.HospitalId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    StageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentStage = table.Column<string>(type: "varchar(50)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.StageId);
                });

            migrationBuilder.CreateTable(
                name: "HospitalAddresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetNumber = table.Column<string>(maxLength: 15, nullable: false),
                    Area = table.Column<string>(maxLength: 30, nullable: false),
                    City = table.Column<string>(maxLength: 20, nullable: false),
                    State = table.Column<string>(maxLength: 20, nullable: false),
                    Country = table.Column<string>(maxLength: 20, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: false),
                    Hospitalid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalAddresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_HospitalAddresses_Hospitals_Hospitalid",
                        column: x => x.Hospitalid,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    LoginId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Gender = table.Column<string>(maxLength: 6, nullable: true),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 16, nullable: false),
                    Roleid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginId);
                    table.ForeignKey(
                        name: "FK_Logins_Roles_Roleid",
                        column: x => x.Roleid,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentDetails",
                columns: table => new
                {
                    TreatmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmitDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Prescription = table.Column<string>(maxLength: 200, nullable: true),
                    RelievingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsFatality = table.Column<string>(maxLength: 10, nullable: true),
                    Stageid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentDetails", x => x.TreatmentId);
                    table.ForeignKey(
                        name: "FK_TreatmentDetails_Stages_Stageid",
                        column: x => x.Stageid,
                        principalTable: "Stages",
                        principalColumn: "StageId");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(type: "varchar(50)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(maxLength: 3, nullable: false),
                    Gender = table.Column<string>(maxLength: 6, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Loginid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Logins_Loginid",
                        column: x => x.Loginid,
                        principalTable: "Logins",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    OccupationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationName = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    WorkType = table.Column<string>(maxLength: 20, nullable: false),
                    Designation = table.Column<string>(maxLength: 20, nullable: false),
                    Patientid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.OccupationId);
                    table.ForeignKey(
                        name: "FK_Occupations_Patients_Patientid",
                        column: x => x.Patientid,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientAddresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetNumber = table.Column<string>(maxLength: 15, nullable: false),
                    Area = table.Column<string>(maxLength: 30, nullable: false),
                    City = table.Column<string>(maxLength: 20, nullable: false),
                    State = table.Column<string>(maxLength: 20, nullable: false),
                    Country = table.Column<string>(maxLength: 20, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: false),
                    Patientid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAddresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_PatientAddresses_Patients_Patientid",
                        column: x => x.Patientid,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentRecords",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: false),
                    Hospitalid = table.Column<int>(nullable: false),
                    Diseaseid = table.Column<int>(nullable: false),
                    Treatmentid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentRecords", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_TreatmentRecords_Diseases_Diseaseid",
                        column: x => x.Diseaseid,
                        principalTable: "Diseases",
                        principalColumn: "DiseaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreatmentRecords_Hospitals_Hospitalid",
                        column: x => x.Hospitalid,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreatmentRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreatmentRecords_TreatmentDetails_Treatmentid",
                        column: x => x.Treatmentid,
                        principalTable: "TreatmentDetails",
                        principalColumn: "TreatmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UniqueIdTypes",
                columns: table => new
                {
                    UniqueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueIdType = table.Column<string>(maxLength: 25, nullable: false),
                    UniqueIdNumber = table.Column<string>(nullable: false),
                    Patientid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueIdTypes", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_UniqueIdTypes_Patients_Patientid",
                        column: x => x.Patientid,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkAddresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetNumber = table.Column<string>(maxLength: 15, nullable: false),
                    Area = table.Column<string>(maxLength: 30, nullable: false),
                    City = table.Column<string>(maxLength: 20, nullable: false),
                    State = table.Column<string>(maxLength: 20, nullable: false),
                    Country = table.Column<string>(maxLength: 20, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: false),
                    Occupationid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkAddresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_WorkAddresses_Occupations_Occupationid",
                        column: x => x.Occupationid,
                        principalTable: "Occupations",
                        principalColumn: "OccupationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HospitalAddresses_Hospitalid",
                table: "HospitalAddresses",
                column: "Hospitalid");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_Email",
                table: "Logins",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logins_Roleid",
                table: "Logins",
                column: "Roleid");

            migrationBuilder.CreateIndex(
                name: "IX_Occupations_Patientid",
                table: "Occupations",
                column: "Patientid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientAddresses_Patientid",
                table: "PatientAddresses",
                column: "Patientid");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Loginid",
                table: "Patients",
                column: "Loginid");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentDetails_Stageid",
                table: "TreatmentDetails",
                column: "Stageid");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentRecords_Diseaseid",
                table: "TreatmentRecords",
                column: "Diseaseid");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentRecords_Hospitalid",
                table: "TreatmentRecords",
                column: "Hospitalid");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentRecords_PatientId",
                table: "TreatmentRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentRecords_Treatmentid",
                table: "TreatmentRecords",
                column: "Treatmentid");

            migrationBuilder.CreateIndex(
                name: "IX_UniqueIdTypes_Patientid",
                table: "UniqueIdTypes",
                column: "Patientid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkAddresses_Occupationid",
                table: "WorkAddresses",
                column: "Occupationid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalAddresses");

            migrationBuilder.DropTable(
                name: "PatientAddresses");

            migrationBuilder.DropTable(
                name: "TreatmentRecords");

            migrationBuilder.DropTable(
                name: "UniqueIdTypes");

            migrationBuilder.DropTable(
                name: "WorkAddresses");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "TreatmentDetails");

            migrationBuilder.DropTable(
                name: "Occupations");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
