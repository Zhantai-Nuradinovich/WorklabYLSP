using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBoilerplate.Shared.Dto.Blog
{
    public class ContentDto
    {
        public DateTime When 
        { 
            get 
            { 
                if (this is ContentFileDto file)
                {
                    return file.CreationDate;
                }
                else if (this is QuizDto quiz)
                {
                    return quiz.CreationDate;
                }
                else if (this is TextDto text)
                {
                    return text.CreationDate;
                }
                return DateTime.Now;
            }
        }
    }
}
