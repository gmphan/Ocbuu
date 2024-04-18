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
            
        }
    }
}
