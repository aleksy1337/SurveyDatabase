using ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Survey
    {
        [Key]
        public int SurveyId { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public SurveyStatus Status { get; set; }

        public virtual User User { get; set; }
    }

}
