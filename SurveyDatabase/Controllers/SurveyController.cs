using ApplicationCore.Models;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SurveyDatabase.API.DTOs;
using SurveyDatabase.API.Requests;

namespace SurveyDatabase.API.Controllers
{
    [Route("api/surveys")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost]
        public ActionResult<SurveyDto> CreateSurvey([FromBody] CreateSurveyRequest request)
        {
            var questions = request.Questions.Select(Mapper.MapFromQuestionDto).ToList();
            var survey = _surveyService.CreateSurvey(request.Title, request.Status, questions);

            if (survey == null)
            {
                return BadRequest();
            }

            var surveyDto = Mapper.MapFromSurvey(survey);

            return Ok(surveyDto);
        }

        [HttpGet]
        [Route("/get/{SurveyId}")]
        public ActionResult<SurveyDto> GetSurveyById([FromRoute] GetSurveyByIdRequest request)
        {
            var survey = _surveyService.GetSurveyById(request.SurveyId);

            if (survey == null)
            {
                return BadRequest();
            }

            var surveyDto = Mapper.MapFromSurvey(survey);

            return Ok(surveyDto);
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<List<SurveyDto>> GetAllSurveys()
        {
            var surveys = _surveyService.GetAllSurveys();
            var surveysDtos = surveys.Select(Mapper.MapFromSurvey);
            return Ok(surveysDtos);
        }

        [HttpGet]
        [Route("user/{UserId}")]
        public ActionResult<List<SurveyDto>> GetUserSurveys([FromRoute] GetUserSurveysRequest request)
        {
            var surveys = _surveyService.GetUserSurveys(request.UserId);

            if (surveys == null)
            {
                return BadRequest();
            }

            var surveysDtos = surveys.Select(Mapper.MapFromSurvey);

            return Ok(surveysDtos);
        }

        [HttpDelete]
        public ActionResult DeleteSurvey(DeleteSurveyRequest request)
        {
            _surveyService.DeleteSurvey(request.SurveyId);
            return NoContent();
        }
    }
}
