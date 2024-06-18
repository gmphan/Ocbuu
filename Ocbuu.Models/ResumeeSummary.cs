using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ocbuu.Models
{
    public class ResumeeSummary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ResumeeHeaderId { get; set; }
        [Required]
        public string? Summary { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [ForeignKey("ResumeeHeaderId")]
        public ResumeeHeader ResumeeHeader { get; set; }
    }
}