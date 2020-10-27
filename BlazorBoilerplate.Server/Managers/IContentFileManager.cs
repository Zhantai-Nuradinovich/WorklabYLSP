using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.Dto.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Server.Managers
{
    public interface IContentFileManager
    {
        Task<ApiResponse> Get(long id);
        Task<ApiResponse> GetOne(long id);
        Task<ApiResponse> Create(ContentFileDto fileDto);
        Task<ApiResponse> Update(ContentFileDto fileDto);
        Task<ApiResponse> Delete(long id);
    }
}
