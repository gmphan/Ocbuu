using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ocbuu.Models
{
    public class ResumeExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        // [MaxLength(20)]
        [DisplayName("Job Title")]
        public string? JobTitle { get; set; }
        [Required]
        public string? Company { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? Zipcode { get; set; }
        [DisplayName("I am currently working in this role")]
        public bool CurrentlyWorkHere { get; set; }
        [Required]
        public string? StartMonth { get; set; }
        [Required]
        public int? StartYear { get; set; }
        public string? EndMonth { get; set; }
        public int? EndYear { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

    }
}