using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.Dto.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Server.Managers
{
    public interface IQuizItemManager
    {
        Task<ApiResponse> Get(long id);
        Task<ApiResponse> GetOne(long id);
        Task<ApiResponse> Create(QuizItemDto quizItemDto);
        Task<ApiResponse> CreateRange(List<QuizItemDto> quizItemDtos);
        Task<ApiResponse> Update(QuizItemDto quizItemDto);
        Task<ApiResponse> Delete(long id);
    }
}
