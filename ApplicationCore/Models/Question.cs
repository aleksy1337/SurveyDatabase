﻿namespace ApplicationCore.Models
{
    public class Question
    {
        public int Id { get; set; }

        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public string QuestionTitle { get; set; }

        public List<QuestionAnswer> QuestionAnswers { get; set; } = new List<QuestionAnswer>();
    }
}
