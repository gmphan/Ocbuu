using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ocbuu.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewResumeeScheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ResumeeHeaders",
                columns: new[] { "Id", "City", "Country", "CreatedDate", "Email", "FirstName", "GitHub", "Headline", "LastName", "LinkedIn", "ModifiedDate", "PhoneNum", "State", "StreetAddress", "Zipcode" },
                values: new object[] { 1, "Morrow", "Clayton", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gmphan7@gmail.com", "Giang", "ocbuugithub", "headline1", "Phan", "gphanLinkedIn", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6780000000", "GA", "2192 Murry Trail", "30260" });

            migrationBuilder.InsertData(
                table: "ResumeeExperiences",
                columns: new[] { "Id", "City", "Company", "Country", "CreatedDate", "CurrentlyWorkHere", "Description", "EndMonth", "EndYear", "JobTitle", "ModifiedDate", "ResumeeHeaderId", "StartMonth", "StartYear", "State", "Zipcode" },
                values: new object[] { 1, "Morrow", "Clayton State", "U.S.A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Coding job", "December", 2024, "Software Engineer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "January", 2000, "GA", "30260" });

            migrationBuilder.InsertData(
                table: "ResumeeSummaries",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "ResumeeHeaderId", "Summary" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "long summary" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ResumeeExperiences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ResumeeSummaries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ResumeeHeaders",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
