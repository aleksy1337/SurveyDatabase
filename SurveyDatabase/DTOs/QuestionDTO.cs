namespace SurveyDatabase.API.DTOs
{
    public class QuestionDTO
    {
        public int SurveyId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
    }
}
