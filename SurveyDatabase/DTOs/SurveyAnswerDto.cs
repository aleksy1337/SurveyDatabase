namespace SurveyDatabase.API.DTOs
{
    public class SurveyAnswerDto
    {
        public int SurveyId { get; set; }
        public IEnumerable<QuestionAnswerDto> QuestionsAnswersDtos { get; set; }
    }
}
