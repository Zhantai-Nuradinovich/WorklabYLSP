using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorBoilerplate.Shared.Dto.Blog
{
    public class ScienceDirectionDto
    {
        [Key]
        public long ScienceDirectionId { get; set; }
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual List<CourseDto> Courses { get; set; }
    }
}
