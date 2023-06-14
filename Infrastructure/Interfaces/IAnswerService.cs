using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAnswerService
    {
        Answer CreateAnswer(int questionId, int surveyId, int userId, string answerText);
        Answer GetAnswerById(int answerId);
        List<Answer> GetAnswersByQuestionId(int questionId);
        List<Answer> GetAnswersBySurveyId(int surveyId);
        List<Answer> GetAnswersByUserId(int userId);
    }
}
