using ApplicationCore.Enums;
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
    public class SurveyService : ISurveyService
    {
        private readonly ApplicationDbContext _context;

        public SurveyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Survey CreateSurvey(int userId, string title, SurveyStatus status)
        {
            var survey = new Survey
            {
                UserId = userId,
                Title = title,
                Status = status
            };

            _context.Surveys.Add(survey);
            _context.SaveChanges();

            return survey;
        }

        public void DeleteSurvey(int surveyId)
        {
            var survey = _context.Surveys.Find(surveyId);
            if (survey != null)
            {
                _context.Surveys.Remove(survey);
                _context.SaveChanges();
            }
        }

        public List<Survey> GetAllSurveys()
        {
            return _context.Surveys.ToList();
        }

        public Survey GetSurveyById(int surveyId)
        {
            return _context.Surveys.Find(surveyId);
        }

        public void UpdateSurvey(Survey survey)
        {
            _context.SaveChanges();
        }
    }
}
