using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTrinhWebNhom3.Migrations
{
    /// <inheritdoc />
    public partial class update7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortfolioProject");

            migrationBuilder.AddColumn<int>(
                name: "PortfoliosId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProjectImageUrl",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PortfoliosId",
                table: "Projects",
                column: "PortfoliosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Portfolios_PortfoliosId",
                table: "Projects",
                column: "PortfoliosId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Portfolios_PortfoliosId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_PortfoliosId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PortfoliosId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectImageUrl",
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
    }
}
