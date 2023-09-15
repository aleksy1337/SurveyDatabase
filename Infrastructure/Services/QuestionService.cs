using ApplicationCore.Models;
using Infrastructure.Data;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public QuestionService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public Question CreateQuestion(int surveyId, string questionTitle)
        {
            var survey = _context.Surveys.Include(x => x.User).FirstOrDefault(x => x.Id == surveyId);

            if (survey == null)
            {
                return null;
            }

            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return null;
            }

            if (survey.UserId != userId)
            {
                return null;
            }

            var question = new Question()
            {
                QuestionTitle = questionTitle,
                SurveyId = surveyId
            };

            _context.Questions.Add(question);
            _context.SaveChanges();
            return question;
        }

        public bool DeleteQuestion(int questionId)
        {
            var question = _context.Questions.FirstOrDefault(x => x.Id == questionId);

            if (question == null)
            {
                return false;
            }
            
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return false;
            }
    
            var survey = _context.Surveys.FirstOrDefault(x => x.Id == question.SurveyId);

            if (survey == null)
            {
                return false;
            }

            if (survey.UserId != userId)
            {
                return false;
            }

            _context.Questions.Remove(question);
            _context.SaveChanges();

            return true;
        }

        public Question GetQuestionById(int questionId)
        {
            var question = _context.Questions.FirstOrDefault(x => x.Id == questionId);

            if (question == null)
            {
                return null;
            }

            return question;
        }

        public List<Question> GetSurveyQuestions(int surveyId)
        {
            var survey = _context.Surveys.Include(x => x.Questions).FirstOrDefault(x => x.Id == surveyId);

            if (survey == null)
            {
                return null;
            }

            var questions = survey.Questions.ToList();

            return questions;
        }

        public Question UpdateQuestion(int questionId)
        {
            throw new NotImplementedException();
        }
    }
}
