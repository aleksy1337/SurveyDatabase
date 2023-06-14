using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public int SurveyId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string AnswerText { get; set; }
    }
}
