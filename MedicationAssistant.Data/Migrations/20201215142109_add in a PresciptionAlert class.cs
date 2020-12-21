using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicationAssistant.Data.Migrations
{
    public partial class addinaPresciptionAlertclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Prescriptions_PrescriptionId",
                table: "Alerts");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_PrescriptionId",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "Alerts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId",
                table: "Alerts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_PrescriptionId",
                table: "Alerts",
                column: "PrescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Prescriptions_PrescriptionId",
                table: "Alerts",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
