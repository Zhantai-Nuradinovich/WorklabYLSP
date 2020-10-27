using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlazorBoilerplate.Shared.DataInterfaces;

namespace BlazorBoilerplate.Shared.DataModels
{
    public class Quiz : IAuditable, ISoftDelete
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string DirectionTitle { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public virtual List<QuizItem> Items { get; set; }
        public long CourseId { get; set; }
        public Course Course { get; set; }
    }
}
