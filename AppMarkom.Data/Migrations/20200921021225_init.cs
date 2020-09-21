using Microsoft.EntityFrameworkCore.Migrations;

namespace AppMarkom.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_m_companies_m_employees_m_employeeId",
                table: "m_companies");

            migrationBuilder.DropIndex(
                name: "IX_m_companies_m_employeeId",
                table: "m_companies");

            migrationBuilder.DropColumn(
                name: "m_employeeId",
                table: "m_companies");

            migrationBuilder.AddColumn<int>(
                name: "MCompanyId",
                table: "m_employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_m_employees_MCompanyId",
                table: "m_employees",
                column: "MCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_m_employees_m_companies_MCompanyId",
                table: "m_employees",
                column: "MCompanyId",
                principalTable: "m_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_m_employees_m_companies_MCompanyId",
                table: "m_employees");

            migrationBuilder.DropIndex(
                name: "IX_m_employees_MCompanyId",
                table: "m_employees");

            migrationBuilder.DropColumn(
                name: "MCompanyId",
                table: "m_employees");

            migrationBuilder.AddColumn<int>(
                name: "m_employeeId",
                table: "m_companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_m_companies_m_employeeId",
                table: "m_companies",
                column: "m_employeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_m_companies_m_employees_m_employeeId",
                table: "m_companies",
                column: "m_employeeId",
                principalTable: "m_employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
