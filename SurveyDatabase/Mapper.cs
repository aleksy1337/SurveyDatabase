using ApplicationCore.Models;
using SurveyDatabase.API.DTOs;

namespace SurveyDatabase.API
{
    public class Mapper
    {
        public static QuestionAnswer MapFromQuestionAnswerDto(QuestionAnswerDto dto)
        {
            return new QuestionAnswer()
            {
                QuestionId = dto.QuestionId,
                SurveyAnswerId = dto.SurveyAnswerId,
                Content = dto.Content
            };
        }

        public static Question MapFromQuestionDto(QuestionDto dto)
        {
            return new Question()
            {
                QuestionTitle = dto.QuestionTitle,
            };
        }

        public static SurveyDto MapFromSurvey(Survey survey)
        {
            return new SurveyDto()
            {
                Title = survey.Title,
                Status = survey.Status.ToString(),
                Questions = survey.Questions.Select(Mapper.MapFromQuestion).ToList()
            };
        }

        public static QuestionDto MapFromQuestion(Question question)
        {
            return new QuestionDto()
            {
                QuestionTitle = question.QuestionTitle
            };
        }

        public static SurveyAnswerDto MapFromSurveyAnswer(SurveyAnswer surveyAnswer)
        {
            return new SurveyAnswerDto()
            {
                SurveyId = surveyAnswer.SurveyId,
                QuestionsAnswersDtos = surveyAnswer.QuestionAnswers.Select(Mapper.MapFromQuestionAnswer).ToList()
            };
        }

        public static QuestionAnswerDto MapFromQuestionAnswer(QuestionAnswer questionAnswer)
        {
            return new QuestionAnswerDto()
            {
                Content = questionAnswer.Content,
                QuestionId = questionAnswer.QuestionId,
                SurveyAnswerId = questionAnswer.SurveyAnswerId
            };
        }

    }
}
