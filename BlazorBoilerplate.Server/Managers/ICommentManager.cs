using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.Dto.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Server.Managers
{
    public interface ICommentManager
    {
        Task<ApiResponse> Get(long id);
        Task<ApiResponse> GetOne(long id);
        Task<ApiResponse> Create(CommentDto commentDto);
        Task<ApiResponse> Update(CommentDto commentDto);
        Task<ApiResponse> Delete(long id);
    }
}
