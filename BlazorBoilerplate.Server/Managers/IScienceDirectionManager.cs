using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.Dto.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Server.Managers
{
    public interface IScienceDirectionManager
    {
        Task<ApiResponse> Get();
        Task<ApiResponse> Get(long id);
        Task<ApiResponse> Create(ScienceDirectionDto scienceDirectionDto);
        Task<ApiResponse> Update(ScienceDirectionDto scienceDirectionDto);
        Task<ApiResponse> Delete(long id);
    }
}
