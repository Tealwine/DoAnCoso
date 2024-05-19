using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTrinhWebNhom3.Migrations
{
    /// <inheritdoc />
    public partial class update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Portfolios_PortfolioId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_PortfolioId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "PortfolioProject",
                columns: table => new
                {
                    portfoliosId = table.Column<int>(type: "int", nullable: false),
                    projectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioProject", x => new { x.portfoliosId, x.projectsId });
                    table.ForeignKey(
                        name: "FK_PortfolioProject_Portfolios_portfoliosId",
                        column: x => x.portfoliosId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioProject_Projects_projectsId",
                        column: x => x.projectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioProject_projectsId",
                table: "PortfolioProject",
                column: "projectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortfolioProject");

            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PortfolioId",
                table: "Projects",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Portfolios_PortfolioId",
                table: "Projects",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id");
        }
    }
}
