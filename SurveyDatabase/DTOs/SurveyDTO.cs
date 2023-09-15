using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace SurveyDatabase.API.DTOs
{
    public class SurveyDto
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
