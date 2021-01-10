using BlazorBoilerplate.Shared.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorBoilerplate.Shared.Dto.Blog
{
    public class TextDto
    {
        [Key]
        public long TextId { get; set; }
        [Required]
        public string TextContent { get; set; }
        public DateTime When { get; set; }
        public long CourseId { get; set; }
    }
}
