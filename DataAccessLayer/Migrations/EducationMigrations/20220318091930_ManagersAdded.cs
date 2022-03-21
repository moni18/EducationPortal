using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations.EducationMigrations
{
    public partial class ManagersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schools_ManagerId",
                table: "Schools",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Manager_ManagerId",
                table: "Schools",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Manager_ManagerId",
                table: "Schools");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropIndex(
                name: "IX_Schools_ManagerId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Schools");
        }
    }
}
