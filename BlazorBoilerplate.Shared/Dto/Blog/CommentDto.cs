using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBoilerplate.Shared.Dto.Blog
{
    public class CommentDto
    {
        public long CommentId { get; set; }
        public long CourseId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime When { get; set; }
        public Guid UserID { get; set; }

        public bool Mine { get; set; }

        public CommentDto() { }

        public CommentDto(int id, string userName, string text, bool mine)
        {
            CommentId = id;
            UserName = userName;
            Text = text;
            Mine = mine;
        }
        public string CSS
        {
            get
            {
                return Mine ? "sent" : "received";
            }
        }
    }
}
