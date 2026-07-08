using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPOS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganizationToState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "States",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_States_OrganizationId",
                table: "States",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Organizations_OrganizationId",
                table: "States",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Organizations_OrganizationId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_OrganizationId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "States");
        }
    }
}
