using BlazorBoilerplate.Shared.DataModels;
using BlazorBoilerplate.Shared.Dto.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Shared.DataInterfaces
{
    public interface ITextStore
    {
        Task<List<TextDto>> GetAllByCourseId(long id);
        Task<TextDto> GetById(long id);
        Task<Text> Create(TextDto textDto);
        Task<Text> Update(TextDto textDto);
        Task DeleteById(long id);
    }
}
