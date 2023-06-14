using ApplicationCore.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SurveyDatabase.API.DTOs;

namespace SurveyDatabase.API.Controllers
{
    [Route("api/answers")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet("{id}")]
        public ActionResult<Answer> GetAnswerById(int id)
        {
            var answer = _answerService.GetAnswerById(id);
            if (answer == null)
            {
                return NotFound();
            }

            return Ok(answer);
        }

        [HttpGet("question/{questionId}")]
        public ActionResult<List<Answer>> GetAnswersByQuestionId(int questionId)
        {
            var answers = _answerService.GetAnswersByQuestionId(questionId);
            return Ok(answers);
        }

        [HttpGet("survey/{surveyId}")]
        public ActionResult<List<Answer>> GetAnswersBySurveyId(int surveyId)
        {
            var answers = _answerService.GetAnswersBySurveyId(surveyId);
            return Ok(answers);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<List<Answer>> GetAnswersByUserId(int userId)
        {
            var answers = _answerService.GetAnswersByUserId(userId);
            return Ok(answers);
        }

        [HttpPost]
        public ActionResult<Answer> CreateAnswer([FromBody] AnswerDTO answerDTO)
        {
            var answer = _answerService.CreateAnswer(answerDTO.QuestionId, answerDTO.SurveyId, answerDTO.UserId, answerDTO.AnswerText);
            return CreatedAtAction(nameof(GetAnswerById), new { id = answer.AnswerId }, answer);
        }
    }

}
