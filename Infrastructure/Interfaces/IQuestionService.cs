using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IQuestionService
    {
        Question CreateQuestion(int surveyId, string questionText, string questionType);
        Question GetQuestionById(int questionId);
        List<Question> GetQuestionsBySurveyId(int surveyId);
        void UpdateQuestion(Question question);
        void DeleteQuestion(int questionId);
    }
}
