using ApplicationCore.Models;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SurveyDatabase.API.DTOs;

namespace SurveyDatabase.API.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        // Question CreateQuestion(int surveyId, string questionTitle);
        // Question GetQuestionById(int questionId);
        // List<Question> GetSurveyQuestions(int surveyId);
        // Question UpdateQuestion(int questionId);
        // bool DeleteQuestion(int questionId);

        

    }
}
