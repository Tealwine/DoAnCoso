using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTrinhWebNhom3.Migrations
{
    /// <inheritdoc />
    public partial class update12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ProjectID",
                table: "Portfolios",
                column: "ProjectID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Projects_ProjectID",
                table: "Portfolios",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Projects_ProjectID",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_ProjectID",
                table: "Portfolios");

            migrationBuilder.AddColumn<int>(
                name: "PortfoliosId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
