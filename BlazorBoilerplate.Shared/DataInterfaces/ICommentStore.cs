using BlazorBoilerplate.Shared.DataModels;
using BlazorBoilerplate.Shared.Dto.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Shared.DataInterfaces
{
    public interface ICommentStore
    {
        Task<List<CommentDto>> GetAllByCourseId(long id);

        Task<CommentDto> GetById(long id);

        Task<Comment> Create(CommentDto commentDto);

        Task<Comment> Update(CommentDto commentDto);
        Task DeleteById(long id);
    }
}
