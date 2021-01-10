using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorBoilerplate.Shared.DataModels
{
    public class Course
    {
        [Key]
        public long CourseId { get; set; }
        [Required]
        [MaxLength(128)]
        public string CourseName { get; set; }
        public string DirectionName { get; set; }
        [Required]
        [MaxLength(256)]
        public string Annotation { get; set; }
        public string PicturePath { get; set; }
        public List<Quiz> Quizzes { get; set; }
        //public List<Theme> Themes { get; set; }
        public List<Text> Texts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
