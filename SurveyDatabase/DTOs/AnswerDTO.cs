namespace SurveyDatabase.API.DTOs
{
    public class AnswerDTO
    {
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public int UserId { get; set; }
        public string AnswerText { get; set; }
    }
}
