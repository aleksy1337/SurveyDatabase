using ApplicationCore.Models;
using Infrastructure.Interfaces;
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

        [HttpGet("{id}")]
        public ActionResult<Question> GetQuestionById(int id)
        {
            var question = _questionService.GetQuestionById(id);
            if (question == null)
                return NotFound("Question by this Id not found");
            return Ok(question);
        }

        [HttpGet("survey/{surveyId}")]
        public ActionResult<List<Question>> GetQuestionsBySurveyId(int surveyId)
        {
            var questions = _questionService.GetQuestionsBySurveyId(surveyId);
            if (questions == null)
                return NotFound("Question by this Survey Id not found ");
            return Ok(questions);
        }

        [HttpPost]
        public ActionResult<Question> CreateQuestion([FromBody] QuestionDTO questionDTO)
        {
            var question = _questionService.CreateQuestion(questionDTO.SurveyId, questionDTO.QuestionText, questionDTO.QuestionType);
            return CreatedAtAction(nameof(GetQuestionById), new { id = question.QuestionId }, question);
        }

        [HttpPut("update/{id}")]
        public ActionResult UpdateQuestion(int id, [FromBody] Question question)
        {
            if (id != question.QuestionId)
            {
                return BadRequest();
            }

            _questionService.UpdateQuestion(question);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteQuestion(int id)
        {
            _questionService.DeleteQuestion(id);
            return NoContent();
        }
    }
}
