using ApplicationCore.Models;

namespace ApplicationCore.Interfaces
{
    public interface IQuestionService
    {
        Question CreateQuestion(int surveyId, string questionTitle);
        Question GetQuestionById(int questionId);
        List<Question> GetSurveyQuestions(int surveyId);
        Question UpdateQuestion(int questionId);
        bool DeleteQuestion(int questionId);
    }
}
