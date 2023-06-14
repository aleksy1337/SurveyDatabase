using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [ForeignKey("QuestionId")]
        [Required]
        public int QuestionId { get; set; }

        [ForeignKey("SurveyId")]
        [Required]
        public int SurveyId { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string AnswerText { get; set; }
    }
}
