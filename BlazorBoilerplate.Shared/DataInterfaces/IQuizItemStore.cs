using BlazorBoilerplate.Shared.DataModels;
using BlazorBoilerplate.Shared.Dto.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Shared.DataInterfaces
{
    public interface IQuizItemStore
    {
        Task<List<QuizItemDto>> GetAllByQuizId(long id);
        Task<QuizItemDto> GetById(long id);
        Task<QuizItem> Create(QuizItemDto quizItemDto);
        Task<List<QuizItem>> CreateRange(List<QuizItemDto> quizItemDtos);
        Task<QuizItem> Update(QuizItemDto quizItemDto);
        Task DeleteById(long id);
    }
}
