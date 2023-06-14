using ApplicationCore.Enums;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ISurveyService
    {
        Survey CreateSurvey(int userId, string title, SurveyStatus status);
        Survey GetSurveyById(int surveyId);
        List<Survey> GetAllSurveys();
        void UpdateSurvey(Survey survey);
        void DeleteSurvey(int surveyId);
    }
}
