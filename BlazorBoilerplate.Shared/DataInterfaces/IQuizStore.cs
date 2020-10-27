using BlazorBoilerplate.Shared.DataModels;
using BlazorBoilerplate.Shared.Dto.Blog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Shared.DataInterfaces
{
    public interface IQuizStore
    {
        Task<List<QuizDto>> GetAllByCourseId(long id);

        Task<QuizDto> GetById(long id);

        Task<Quiz> Create(QuizDto quizDto);

        Task<Quiz> Update(QuizDto quizDto);
        Task DeleteById(long id);
    }
}
