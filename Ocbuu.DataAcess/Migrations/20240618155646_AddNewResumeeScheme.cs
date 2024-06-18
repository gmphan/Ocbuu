using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ocbuu.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewResumeeScheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResumeeHeaders",
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
                    table.PrimaryKey("PK_ResumeeHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResumeeExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResumeeHeaderId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_ResumeeExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeeExperiences_ResumeeHeaders_ResumeeHeaderId",
                        column: x => x.ResumeeHeaderId,
                        principalTable: "ResumeeHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeeSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResumeeHeaderId = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeeSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeeSummaries_ResumeeHeaders_ResumeeHeaderId",
                        column: x => x.ResumeeHeaderId,
                        principalTable: "ResumeeHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResumeeExperiences_ResumeeHeaderId",
                table: "ResumeeExperiences",
                column: "ResumeeHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeeSummaries_ResumeeHeaderId",
                table: "ResumeeSummaries",
                column: "ResumeeHeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResumeeExperiences");

            migrationBuilder.DropTable(
                name: "ResumeeSummaries");

            migrationBuilder.DropTable(
                name: "ResumeeHeaders");
        }
    }
}
