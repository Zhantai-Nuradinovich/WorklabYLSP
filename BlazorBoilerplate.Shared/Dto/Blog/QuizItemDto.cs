using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorBoilerplate.Shared.Dto.Blog
{
    public class QuizItemDto
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Question { get; set; }

        public string PicturePath { get; set; }

        [Required]
        public string Answers { get; set; }

        [Required]
        public string RightAnswer { get; set; }
        public string QuestionType { get; set; }

        public long QuizId { get; set; }

        [NotMapped]
        public string ChoosenAnswer { get; set; }

        [NotMapped]
        public string[] Normalized 
        { 
            get { return Answers.Split("1NZN1"); } 
        }

        public QuizItemDto(QuizItemDto quizItem, string ChoosenAns)
        {
            Id = quizItem.Id;
            Question = quizItem.Question;
            PicturePath = quizItem.PicturePath;
            Answers = quizItem.Answers;
            RightAnswer = quizItem.RightAnswer;
            QuizId = quizItem.QuizId;
            ChoosenAnswer = ChoosenAns;
        }

        public QuizItemDto()
        {

        }
    }
}
