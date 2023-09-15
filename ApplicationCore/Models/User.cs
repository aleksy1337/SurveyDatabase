using Microsoft.AspNet.Identity.EntityFramework;

namespace ApplicationCore.Models
{
    public class User : IdentityUser
    {
        public List<Survey> Surveys { get; set; } = new List<Survey>();
        public List<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();
    }
}
