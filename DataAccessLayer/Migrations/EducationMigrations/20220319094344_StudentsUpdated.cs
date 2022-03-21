using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations.EducationMigrations
{
    public partial class StudentsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Managers_ManagerId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Schools_SchoolId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_ManagerId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_Student_SchoolId",
                table: "Students",
                newName: "IX_Students_SchoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Schools_SchoolId",
                table: "Students",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Schools_SchoolId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameIndex(
                name: "IX_Students_SchoolId",
                table: "Student",
                newName: "IX_Student_SchoolId");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ManagerId",
                table: "Student",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Managers_ManagerId",
                table: "Student",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Schools_SchoolId",
                table: "Student",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
