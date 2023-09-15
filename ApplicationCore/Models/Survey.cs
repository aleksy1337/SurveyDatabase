using ApplicationCore.Enums;

namespace ApplicationCore.Models
{
    public class Survey
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public string Title { get; set; }
        public SurveyStatus Status { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();

        public List<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();
    }

}
