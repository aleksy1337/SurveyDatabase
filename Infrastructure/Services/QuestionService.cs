using ApplicationCore.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class QuestionService : IQuestionService
    {

        private readonly ApplicationDbContext _context;

        public QuestionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Question CreateQuestion(int surveyId, string questionText, string questionType)
        {
            var question = new Question
            {
                SurveyId = surveyId,
                QuestionText = questionText,
                QuestionType = questionType
            };

            _context.Questions.Add(question);
            _context.SaveChanges();

            return question;
        }

        public void DeleteQuestion(int questionId)
        {
            var question = _context.Questions.Find(questionId);
            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
        }

        public Question GetQuestionById(int questionId)
        {
            return _context.Questions.Find(questionId);
        }

        public List<Question> GetQuestionsBySurveyId(int surveyId)
        {
            return _context.Questions.Where(q => q.SurveyId == surveyId).ToList();
        }

        public void UpdateQuestion(Question question)
        {
            _context.SaveChanges();
        }
    }
}
