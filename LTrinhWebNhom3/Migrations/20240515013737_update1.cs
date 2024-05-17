using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTrinhWebNhom3.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioProject_Portfolios_PortfoliosId",
                table: "PortfolioProject");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioProject_Project_ProjectsId",
                table: "PortfolioProject");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImage_Project_ProjectId",
                table: "ProjectImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "PersonalDetailId",
                table: "Portfolios");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "projects");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "PortfolioProject",
                newName: "projectsId");

            migrationBuilder.RenameColumn(
                name: "PortfoliosId",
                table: "PortfolioProject",
                newName: "portfoliosId");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioProject_ProjectsId",
                table: "PortfolioProject",
                newName: "IX_PortfolioProject_projectsId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProjectUrl",
                table: "projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "projects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_projects",
                table: "projects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioProject_Portfolios_portfoliosId",
                table: "PortfolioProject",
                column: "portfoliosId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioProject_projects_projectsId",
                table: "PortfolioProject",
                column: "projectsId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectImage_projects_ProjectId",
                table: "ProjectImage",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioProject_Portfolios_portfoliosId",
                table: "PortfolioProject");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioProject_projects_projectsId",
                table: "PortfolioProject");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImage_projects_ProjectId",
                table: "ProjectImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projects",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "ProjectUrl",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "projects");

            migrationBuilder.RenameTable(
                name: "projects",
                newName: "Project");

            migrationBuilder.RenameColumn(
                name: "projectsId",
                table: "PortfolioProject",
                newName: "ProjectsId");

            migrationBuilder.RenameColumn(
                name: "portfoliosId",
                table: "PortfolioProject",
                newName: "PortfoliosId");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioProject_projectsId",
                table: "PortfolioProject",
                newName: "IX_PortfolioProject_ProjectsId");

            migrationBuilder.AddColumn<int>(
                name: "PersonalDetailId",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioProject_Portfolios_PortfoliosId",
                table: "PortfolioProject",
                column: "PortfoliosId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioProject_Project_ProjectsId",
                table: "PortfolioProject",
                column: "ProjectsId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectImage_Project_ProjectId",
                table: "ProjectImage",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
