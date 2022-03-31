using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations.Hospital
{
    public partial class IdentNumberToPatientAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentNumber",
                table: "Patients",
                type: "nchar(12)",
                fixedLength: true,
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IdentNumber",
                table: "Patients",
                column: "IdentNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_IdentNumber",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IdentNumber",
                table: "Patients");
        }
    }
}
