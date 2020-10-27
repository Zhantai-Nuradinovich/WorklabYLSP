using System.Threading.Tasks;
using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.Dto.Blog;

namespace BlazorBoilerplate.Server.Managers
{
    public interface IQuizManager
    {
        Task<ApiResponse> Get(long id);
        Task<ApiResponse> GetOne(long id);
        Task<ApiResponse> Create(QuizDto quizDto);
        Task<ApiResponse> Update(QuizDto quizDto);
        Task<ApiResponse> Delete(long id);
    }
}