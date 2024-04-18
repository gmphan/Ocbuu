using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ocbuu.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class SeedSummaryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ResumeSummaries",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Summary" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "long summary" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ResumeSummaries",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
