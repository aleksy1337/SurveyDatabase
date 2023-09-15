namespace ApplicationCore.Models
{
    public class QuestionAnswer
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int SurveyAnswerId { get; set; }
        public SurveyAnswer SurveyAnswer { get; set; }

        public string Content { get; set; }
    }
}
