namespace ApplicationCore.Models
{
    public class SurveyAnswer
    {
        public int Id { get; set; }

        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public List<QuestionAnswer> QuestionAnswers { get; set; } = new List<QuestionAnswer>();
    }
}
