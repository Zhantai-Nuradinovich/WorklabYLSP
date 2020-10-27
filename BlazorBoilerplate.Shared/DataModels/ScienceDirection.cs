using BlazorBoilerplate.Shared.DataInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorBoilerplate.Shared.DataModels
{
    public class ScienceDirection : IAuditable, ISoftDelete
    {
        [Key]
        public long ScienceDirectionId { get; set; }
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
