using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BlazorBoilerplate.Shared.Dto.Blog
{
    public class QuizDto
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string QuizName { get; set; }

        public DateTime When { get; set; }

        [Required]
        public virtual List<QuizItemDto> Items { get; set; }

        public long CourseId { get; set; }
        public static string TotalScore(List<QuizItemDto> finishedQuiz)
        {
            List<QuizItemDto> items = new List<QuizItemDto>(finishedQuiz.Where(x => x.RightAnswer == x.ChoosenAnswer));
            double res = (double)items.Count / finishedQuiz.Count * 100;
            return res + "";
        }
    }
}
