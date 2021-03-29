using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicationAssistant.DAL.Migrations
{
	public partial class adduserIdtomediciation : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "UserId",
				table: "Medications",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "UserId",
				table: "Medications");
		}
	}
}
