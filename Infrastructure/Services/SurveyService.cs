using ApplicationCore.Enums;
using ApplicationCore.Models;
using Infrastructure.Data;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccesor;

        public SurveyService(ApplicationDbContext context, IHttpContextAccessor httpContextAccesor)
        {
            _context = context;
            _httpContextAccesor = httpContextAccesor;
        }

        public Survey CreateSurvey(string title, SurveyStatus status, List<Question> questions)
        {
            var userId = _httpContextAccesor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return null;
            }

            var survey = new Survey()
            {
                Title = title,
                UserId = userId,
                Status = status,
                Questions = questions
            };

            _context.Surveys.Add(survey);
            _context.SaveChanges();

            return survey;
        }

        public bool DeleteSurvey(int surveyId)
        {
            var userId = _httpContextAccesor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return false;
            }
            
            var survey = _context.Surveys.FirstOrDefault(x => x.Id == surveyId);

            if (survey == null)
            {
                return false;
            }

            if (survey.UserId != userId)
            {
                return false;
            }

            _context.Surveys.Remove(survey);
            _context.SaveChanges();

            return true;
        }

        public List<Survey> GetAllSurveys()
        {
            return _context.Surveys.Include(x => x.Questions).ToList();
        }

        public Survey GetSurveyById(int surveyId)
        {
            return _context.Surveys.FirstOrDefault(x => x.Id == surveyId);
        }

        public List<Survey> GetUserSurveys(string userId)
        {
            return _context.Surveys.Where(x => x.UserId == userId).ToList();
        }

        public Survey UpdateSurvey(Survey survey)
        {
            throw new NotImplementedException();
        }
    }
}
