using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorBoilerplate.Shared.DataModels
{
    public class Comment
    {
        [Key]
        public long CommentId { get; set; }
        public long CourseId { get; set; }
        public Course Course { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime When { get; set; }
        public Guid UserID { get; set; }
        public ApplicationUser Sender { get; set; }
    }
}
