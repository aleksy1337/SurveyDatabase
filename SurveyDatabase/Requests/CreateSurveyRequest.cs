using ApplicationCore.Enums;
using SurveyDatabase.API.DTOs;

namespace SurveyDatabase.API.Requests
{
    public class CreateSurveyRequest
    {
        public string Title { get; set; }
        public SurveyStatus Status { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
