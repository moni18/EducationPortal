using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations.Hospital
{
    public partial class ReceptionsUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Complaint",
                table: "Receptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Receptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Treatment",
                table: "Receptions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complaint",
                table: "Receptions");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Receptions");

            migrationBuilder.DropColumn(
                name: "Treatment",
                table: "Receptions");
        }
    }
}
