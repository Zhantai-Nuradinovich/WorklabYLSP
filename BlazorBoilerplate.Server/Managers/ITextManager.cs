using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.Dto.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Server.Managers
{
    public interface ITextManager
    {
        Task<ApiResponse> Get(long id);
        Task<ApiResponse> GetOne(long id);
        Task<ApiResponse> Create(TextDto textDto);
        Task<ApiResponse> Update(TextDto textDto);
        Task<ApiResponse> Delete(long id);
    }
}
