using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ocbuu.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnToResumeHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "ResumeHeaders",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ResumeHeaders",
                keyColumn: "Id",
                keyValue: 1,
                column: "MiddleName",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "ResumeHeaders");
        }
    }
}
