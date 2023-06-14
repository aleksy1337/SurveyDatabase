using ApplicationCore.Enums;

namespace SurveyDatabase.API.DTOs
{
    public class SurveyDTO
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public SurveyStatus Status { get; set; }
    }
}
