using Microsoft.EntityFrameworkCore;
using Ocbuu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ocbuu.DataAcess
{
    public class AzurePgDbContext : DbContext
    {
        public AzurePgDbContext(DbContextOptions<AzurePgDbContext> options) : base(options)
        {

        }

        public DbSet<ResumeHeader> ResumeHeaders { get; set; }
        public DbSet<ResumeExperience> ResumeExperiences { get; set; }
        public DbSet<ResumeSummary> ResumeSummaries { get; set; }
        public DbSet<ResumeeHeader> ResumeeHeaders { get; set; }
        public DbSet<ResumeeExperience> ResumeeExperiences { get; set; }
        public DbSet<ResumeeSummary> ResumeeSummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<ResumeHeader>().HasData(
                new ResumeHeader
                {
                    Id = 1,
                    City = "Morrow",
                    Country = "Clayton",
                    CreatedDate = new DateTime(),
                    Email = "gmphan7@gmail.com",
                    FirstName = "Giang",
                    GitHub = "ocbuugithub",
                    Headline = "headline1",
                    LastName = "Phan",
                    LinkedIn = "gphanLinkedIn",
                    ModifiedDate = new DateTime(),
                    PhoneNum = "6780000000",
                    State = "GA",
                    StreetAddress = "2192 Murry Trail",
                    Zipcode = "30260"
                }
            );
            _= modelBuilder.Entity<ResumeExperience>().HasData(
                new ResumeExperience
                {
                    Id = 1,
                    JobTitle = "Software Engineer",
                    Company = "Clayton State",
                    Country = "U.S.A",
                    City = "Morrow",
                    State = "GA",
                    Zipcode = "30260",
                    CurrentlyWorkHere = true,
                    StartMonth = "January",
                    StartYear = 2000,
                    EndMonth = "December",
                    EndYear = 2024,
                    Description = "Coding job",
                    CreatedDate = new DateTime(),
                    ModifiedDate = new DateTime()
                }
            );
            _= modelBuilder.Entity<ResumeSummary>().HasData(
                new ResumeSummary
                {
                    Id = 1,
                    Summary = "long summary",
                    CreatedDate = new DateTime(),
                    ModifiedDate = new DateTime()
                }
            );

            // for new set of Resume
            _= modelBuilder.Entity<ResumeeHeader>()
                .HasMany(r => r.Summaries)
                .WithOne(s => s.ResumeeHeader)
                .HasForeignKey(s => s.ResumeeHeaderId);
            _ = modelBuilder.Entity<ResumeeHeader>()
                .HasMany(r => r.Experiences)
                .WithOne(e => e.ResumeeHeader)
                .HasForeignKey(e => e.ResumeeHeaderId);

            _ = modelBuilder.Entity<ResumeeHeader>().HasData(
                new ResumeeHeader
                {
                    Id = 1, // Ensure this matches the foreign key references
                    City = "Morrow",
                    Country = "Clayton",
                    CreatedDate = new DateTime(),
                    Email = "gmphan7@gmail.com",
                    FirstName = "Giang",
                    GitHub = "ocbuugithub",
                    Headline = "headline1",
                    LastName = "Phan",
                    LinkedIn = "gphanLinkedIn",
                    ModifiedDate = new DateTime(),
                    PhoneNum = "6780000000",
                    State = "GA",
                    StreetAddress = "2192 Murry Trail",
                    Zipcode = "30260"
                }
            );
            _ = modelBuilder.Entity<ResumeeSummary>().HasData(
                new ResumeeSummary
                {
                    Id = 1, // Ensure unique ID
                    ResumeeHeaderId = 1, // Link to the seeded ResumeeHeader
                    Summary = "long summary",
                    CreatedDate = new DateTime(),
                    ModifiedDate = new DateTime(),
                    
                }
            );
            _= modelBuilder.Entity<ResumeeExperience>().HasData(
                new ResumeeExperience
                {
                    Id = 1, // Ensure unique ID
                    ResumeeHeaderId = 1, // Link to the seeded ResumeeHeader
                    JobTitle = "Software Engineer",
                    Company = "Clayton State",
                    Country = "U.S.A",
                    City = "Morrow",
                    State = "GA",
                    Zipcode = "30260",
                    CurrentlyWorkHere = true,
                    StartMonth = "January",
                    StartYear = 2000,
                    EndMonth = "December",
                    EndYear = 2024,
                    Description = "Coding job",
                    CreatedDate = new DateTime(),
                    ModifiedDate = new DateTime()
                }
            );
            
            
        }
    }
}
