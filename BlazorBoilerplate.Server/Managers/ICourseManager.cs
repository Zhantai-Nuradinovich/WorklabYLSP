using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.Dto.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Server.Managers
{
    public interface ICourseManager
    {
        Task<ApiResponse> Get();
        Task<ApiResponse> GetOne(long id);
        Task<ApiResponse> Create(CourseDto courseDto);
        Task<ApiResponse> Update(CourseDto courseDto);
        Task<ApiResponse> Delete(long id);
    }
}
