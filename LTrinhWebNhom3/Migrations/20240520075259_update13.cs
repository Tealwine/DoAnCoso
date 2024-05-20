using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTrinhWebNhom3.Migrations
{
    /// <inheritdoc />
    public partial class update13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Portfolios_ProjectID",
                table: "Portfolios");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ProjectID",
                table: "Portfolios",
                column: "ProjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Portfolios_ProjectID",
                table: "Portfolios");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ProjectID",
                table: "Portfolios",
                column: "ProjectID",
                unique: true);
        }
    }
}
