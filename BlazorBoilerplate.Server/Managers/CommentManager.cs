using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.Dto.Blog;
using static Microsoft.AspNetCore.Http.StatusCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.DataInterfaces;
using System.IO;

namespace BlazorBoilerplate.Server.Managers
{
    public class CommentManager : ICommentManager
    {
        private readonly ICommentStore _commentStore;

        public CommentManager(ICommentStore commentStore)
        {
            _commentStore = commentStore;
        }
        public async Task<ApiResponse> Create(CommentDto commentDto)
        {
            var comment = await _commentStore.Create(commentDto);
            return new ApiResponse(Status200OK, "Created comment", comment);
        }

        public async Task<ApiResponse> Delete(long id)
        {
            try
            {
                await _commentStore.DeleteById(id);
                return new ApiResponse(Status200OK, "Soft Delete comment");
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update comment");
            }
        }

        public async Task<ApiResponse> Get(long id)
        {
            try
            {
                return new ApiResponse(Status200OK, "Retrieved Quizzes", await _commentStore.GetAllByCourseId(id));
            }
            catch (Exception ex)
            {
                return new ApiResponse(Status400BadRequest, ex.Message);
            }
        }

        public async Task<ApiResponse> GetOne(long id)
        {
            try
            {
                return new ApiResponse(Status200OK, "Retrieved comment", await _commentStore.GetById(id));
            }
            catch (Exception e)
            {
                return new ApiResponse(Status400BadRequest, "Failed to Retrieve comment");
            }
        }

        public async Task<ApiResponse> Update(CommentDto commentDto)
        {
            try
            {
                return new ApiResponse(Status200OK, "Updated comment", await _commentStore.Update(commentDto));
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update comment");
            }
        }
    }
}
