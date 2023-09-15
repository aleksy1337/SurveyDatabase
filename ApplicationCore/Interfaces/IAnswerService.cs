using ApplicationCore.Models;

namespace ApplicationCore.Interfaces
{
    public interface IAnswerService
    {
        SurveyAnswer CreateAnswer(int surveyId, List<QuestionAnswer> answers);
        List<SurveyAnswer> GetSurveyAnswers(int surveyId);
        List<SurveyAnswer> GetUserAnswers();
        List<QuestionAnswer> GetQuestionAnswers(int questionId);
        bool DeleteAnswer(int surveyAnswerId);
    }
}
