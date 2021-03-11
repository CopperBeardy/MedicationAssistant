using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicationAssistant.DAL.Migrations
{
    public partial class removemedicinedetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_MedicineDetails_MedicineDetailsId",
                table: "Medications");

            migrationBuilder.DropTable(
                name: "MedicineDetails");

            migrationBuilder.DropIndex(
                name: "IX_Medications_MedicineDetailsId",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "MedicineDetailsId",
                table: "Medications");

            migrationBuilder.AddColumn<string>(
                name: "UseDirections",
                table: "Medications",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseDirections",
                table: "Medications");

            migrationBuilder.AddColumn<int>(
                name: "MedicineDetailsId",
                table: "Medications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MedicineDetails",
                columns: table => new
                {
                    MedicineDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UseDirections = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDetails", x => x.MedicineDetailId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medications_MedicineDetailsId",
                table: "Medications",
                column: "MedicineDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_MedicineDetails_MedicineDetailsId",
                table: "Medications",
                column: "MedicineDetailsId",
                principalTable: "MedicineDetails",
                principalColumn: "MedicineDetailId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
