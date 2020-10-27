using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorBoilerplate.Shared.DataModels
{
    public class ContentFile
    {
        [Key]
        public int ContentFileId { get; set; }
        [MaxLength(128)]
        public string ContentFileName { get; set; }
        [Required]
        public string ContentFilePath { get; set; }
        public DateTime CreationDate { get; set; }
        public long CourseId { get; set; }
        public Course Course { get; set; }
    }
}
