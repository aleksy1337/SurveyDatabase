using ApplicationCore.Enums;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces
{
    public interface ISurveyService
    {
        Survey CreateSurvey(string title, SurveyStatus status, List<Question> questions);
        Survey GetSurveyById(int surveyId);
        List<Survey> GetAllSurveys();
        List<Survey> GetUserSurveys(string userId);
        Survey UpdateSurvey(Survey survey);
        bool DeleteSurvey(int surveyId);
    }
}
