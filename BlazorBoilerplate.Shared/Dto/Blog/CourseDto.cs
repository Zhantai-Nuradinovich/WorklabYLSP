using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorBoilerplate.Shared.Dto.Blog
{
    public class CourseDto
    {
        [Key]
        public long CourseId { get; set; }
        public long ScienceDirectionId { get; set; }
        [Required]
        [MaxLength(128)]
        public string CourseName { get; set; }
        [Required]
        [MaxLength(256)]
        public string Description { get; set; }
        public List<ContentFileDto> Files { get; set; }
        public List<QuizDto> Quizzes { get; set; }
        //public List<Theme> Themes { get; set; }
        public List<TextDto> Texts { get; set; }
        public virtual ICollection<CommentDto> Comments { get; set; }
    }
}
