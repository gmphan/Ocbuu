using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ocbuu.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class InitAddAllResumeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResumeExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobTitle = table.Column<string>(type: "text", nullable: false),
                    Company = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Zipcode = table.Column<string>(type: "text", nullable: false),
                    CurrentlyWorkHere = table.Column<bool>(type: "boolean", nullable: false),
                    StartMonth = table.Column<string>(type: "text", nullable: false),
                    StartYear = table.Column<int>(type: "integer", nullable: false),
                    EndMonth = table.Column<string>(type: "text", nullable: true),
                    EndYear = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeExperiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResumeHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Headline = table.Column<string>(type: "text", nullable: false),
                    PhoneNum = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    StreetAddress = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Zipcode = table.Column<string>(type: "text", nullable: false),
                    LinkedIn = table.Column<string>(type: "text", nullable: true),
                    GitHub = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResumeSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Summary = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSummaries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ResumeExperiences",
                columns: new[] { "Id", "City", "Company", "Country", "CreatedDate", "CurrentlyWorkHere", "Description", "EndMonth", "EndYear", "JobTitle", "ModifiedDate", "StartMonth", "StartYear", "State", "Zipcode" },
                values: new object[] { 1, "Morrow", "Clayton State", "U.S.A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Coding job", "December", 2024, "Software Engineer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "January", 2000, "GA", "30260" });

            migrationBuilder.InsertData(
                table: "ResumeHeaders",
                columns: new[] { "Id", "City", "Country", "CreatedDate", "Email", "FirstName", "GitHub", "Headline", "LastName", "LinkedIn", "ModifiedDate", "PhoneNum", "State", "StreetAddress", "Zipcode" },
                values: new object[] { 1, "Morrow", "Clayton", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gmphan7@gmail.com", "Giang", "ocbuugithub", "headline1", "Phan", "gphanLinkedIn", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6780000000", "GA", "2192 Murry Trail", "30260" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResumeExperiences");

            migrationBuilder.DropTable(
                name: "ResumeHeaders");

            migrationBuilder.DropTable(
                name: "ResumeSummaries");
        }
    }
}
