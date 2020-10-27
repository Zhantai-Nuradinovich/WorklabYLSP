using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorBoilerplate.Shared.DataModels
{
    public class QuizItem
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
    }
}
