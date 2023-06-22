using ApplicationCore.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SurveyDatabase.API.DTOs;

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

        [HttpGet]
        public ActionResult<List<Survey>> GetAllSurveys()
        {
            var surveys = _surveyService.GetAllSurveys();
            return Ok(surveys);
        }

        [HttpGet("{id}")]
        public ActionResult<Survey> GetSurveyById(int id)
        {
            var survey = _surveyService.GetSurveyById(id);
            if (survey == null)
                return NotFound("Survey by this Id not found ");
            return Ok(survey);
        }

        [HttpPost("create")]
        public ActionResult<Survey> CreateSurvey([FromBody] SurveyDTO surveyDTO)
        {
            var survey = _surveyService.CreateSurvey(surveyDTO.UserId, surveyDTO.Title, surveyDTO.Status);
            return CreatedAtAction(nameof(GetSurveyById), new { id = survey.SurveyId }, survey);
        }

        [HttpPut("update/{id}")]
        public ActionResult UpdateSurvey(int id, [FromBody] Survey survey)
        {
            if (id != survey.SurveyId)
            {
                return BadRequest();
            }

            _surveyService.UpdateSurvey(survey);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteSurvey(int id)
        {
            _surveyService.DeleteSurvey(id);
            return NoContent();
        }
    }
}
