using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorBoilerplate.Shared.Dto.Blog
{
    public class ContentFileDto : ContentDto
    {
        [Key]
        public int ContentFileId { get; set; }
        [MaxLength(128)]
        public string ContentFileName { get; set; }
        [Required]
        public string ContentFilePath { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public long CourseId { get; set; }
    }
}
