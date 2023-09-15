using ApplicationCore.Models;
using Infrastructure.Data;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AnswerService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public SurveyAnswer CreateAnswer(int surveyId, List<QuestionAnswer> answers)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return null;
            }

            var answer = new SurveyAnswer()
            {
                Id = surveyId,
                UserId = userId,
                QuestionAnswers = answers
            };

            _context.SurveyAnswers.Add(answer);
            _context.SaveChanges();

            return answer;
        }

        public bool DeleteAnswer(int surveyAnswerId)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return false;
            }

            var surveyAnswer = _context.SurveyAnswers.Include(x => x.User).FirstOrDefault(x => x.Id == surveyAnswerId);

            if (surveyAnswer == null)
            {
                return false;
            }

            var ownerId = surveyAnswer.User.Id;

            if (userId != ownerId)
            {
                return false;
            }

            _context.Remove(surveyAnswer);
            _context.SaveChanges();

            return true;
        }

        public List<QuestionAnswer> GetQuestionAnswers(int questionId)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return null;
            }

            var questionAnswer = _context.QuestionAnswers.Include(x => x.SurveyAnswer).ThenInclude(x => x.User).FirstOrDefault(x => x.Id == questionId);

            if (questionAnswer == null)
            {
                return null;
            }

            var ownerId = questionAnswer.SurveyAnswer.User.Id;

            if (userId != ownerId)
            {
                return null;
            }

            var questionAnswers = _context.QuestionAnswers.Where(x => x.Id ==  questionId).ToList();
            
            return questionAnswers;
        }

        public List<SurveyAnswer> GetSurveyAnswers(int surveyId)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return null;
            }

            var survey = _context.Surveys.Include(x => x.User).FirstOrDefault(x => x.Id == surveyId);

            if (survey == null)
            {
                return null;
            }

            var ownerId = survey.User.Id;

            if (userId != ownerId)
            {
                return null;
            }

            var surveyAnswers = _context.SurveyAnswers.Include(x => x.QuestionAnswers).Where(x => x.SurveyId ==  surveyId).ToList();
            
            return surveyAnswers;
        }

        public List<SurveyAnswer> GetUserAnswers()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return null;
            }
            
            return _context.SurveyAnswers.Where(x => x.UserId == userId).ToList();
        }
    }
}
