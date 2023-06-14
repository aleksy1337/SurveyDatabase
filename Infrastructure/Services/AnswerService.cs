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
    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext _context;

        public AnswerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Answer CreateAnswer(int questionId, int surveyId, int userId, string answerText)
        {
            var answer = new Answer
            {
                QuestionId = questionId,
                SurveyId = surveyId,
                UserId = userId,
                AnswerText = answerText
            };

            _context.Answers.Add(answer);
            _context.SaveChanges();

            return answer;
        }

        public Answer GetAnswerById(int answerId)
        {
            return _context.Answers.Find(answerId);
        }

        public List<Answer> GetAnswersByQuestionId(int questionId)
        {
            return _context.Answers.Where(a => a.QuestionId == questionId).ToList();
        }

        public List<Answer> GetAnswersBySurveyId(int surveyId)
        {
            return _context.Answers.Where(a => a.SurveyId == surveyId).ToList();
        }

        public List<Answer> GetAnswersByUserId(int userId)
        {
            return _context.Answers.Where(a => a.UserId == userId).ToList();
        }
    }
}
