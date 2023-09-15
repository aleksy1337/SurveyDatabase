using ApplicationCore.Models;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SurveyDatabase.API.DTOs;
using SurveyDatabase.API.Requests;

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

        [HttpGet]
        public ActionResult<SurveyAnswerDto> CreateAnswer([FromBody] SurveyAnswerDto request)
        {
            var questionsAnswers = request.QuestionsAnswersDtos.Select(Mapper.MapFromQuestionAnswerDto).ToList();
            var answer = _answerService.CreateAnswer(request.SurveyId, questionsAnswers);

            var answerDto = Mapper.MapFromSurveyAnswer(answer);

            return Ok(answerDto);
        }

        [HttpGet]
        [Route("survey/{SurveyId}")]
        public ActionResult<List<SurveyAnswerDto>> GetSurveyAnswers([FromRoute] GetSurveyAnswersRequest request)
        {
            var surveyAnswers = _answerService.GetSurveyAnswers(request.SurveyId);

            if (surveyAnswers == null) 
            {
                return BadRequest();
            }

            var surveyAnswersDtos = surveyAnswers.Select(Mapper.MapFromSurveyAnswer).ToList();

            return Ok(surveyAnswersDtos);
        }

        [HttpGet]
        [Route("me")]
        public ActionResult<List<SurveyAnswerDto>> GetMyAnswers()
        {
            var userAnswers = _answerService.GetUserAnswers();

            if (userAnswers == null)
            {
                return BadRequest();
            }

            var userAnswersDtos = userAnswers.Select(Mapper.MapFromSurveyAnswer);

            return Ok(userAnswersDtos);
        }

        [HttpGet]
        [Route("question/{QuestionId}")]
        public ActionResult<List<QuestionAnswerDto>> GetQuestionAnswers([FromRoute] GetQuestionAnswersRequest request)
        {
            var questionAnswers = _answerService.GetQuestionAnswers(request.QuestionId);

            if (questionAnswers == null)
            {
                return BadRequest();
            }

            var questionAnswersDtos = questionAnswers.Select(Mapper.MapFromQuestionAnswer);

            return Ok(questionAnswersDtos);
        }

        [HttpDelete]
        public ActionResult DeleteAnswer([FromBody] DeleteAnswerRequest deleteAnswerRequest)
        {
            if (_answerService.DeleteAnswer(deleteAnswerRequest.AnswerId))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}


