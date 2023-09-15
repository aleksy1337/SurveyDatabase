namespace SurveyDatabase.API.DTOs
{
    public class QuestionAnswerDto
    {
        public int QuestionId { get; set; }
        public int SurveyAnswerId { get; set; }
        public string Content { get; set; }
    }
}
