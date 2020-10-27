using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorBoilerplate.Shared.DataModels
{
    public class Text
    {
        [Key]
        public long TextId { get; set; }
        [Required]
        public string TextContent { get; set; }
        public DateTime CreationDate { get; set; }
        public long CourseId { get; set; }
        public Course Course { get; set; }
    }
}
