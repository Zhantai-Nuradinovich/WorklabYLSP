using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.DataInterfaces;
using BlazorBoilerplate.Shared.Dto.Blog;
using static Microsoft.AspNetCore.Http.StatusCodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Server.Managers
{
    public class ContentFileManager : IContentFileManager
    {
        private readonly IContentFileStore _contentFileStore;

        public ContentFileManager(IContentFileStore contentFileStore)
        {
            _contentFileStore = contentFileStore;
        }
        public async Task<ApiResponse> Create(ContentFileDto fileDto)
        {
            var contentFile = await _contentFileStore.Create(fileDto);
            return new ApiResponse(Status200OK, "Created contentFile", contentFile);
        }

        public async Task<ApiResponse> Delete(long id)
        {
            try
            {
                await _contentFileStore.DeleteById(id);
                return new ApiResponse(Status200OK, "Soft Delete contentFile");
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update contentFile");
            }
        }

        public async Task<ApiResponse> Get(long id)
        {
            try
            {
                return new ApiResponse(Status200OK, "Retrieved Quizzes", await _contentFileStore.GetAllByCourseId(id));
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
                return new ApiResponse(Status200OK, "Retrieved contentFile", await _contentFileStore.GetById(id));
            }
            catch (Exception e)
            {
                return new ApiResponse(Status400BadRequest, "Failed to Retrieve contentFile");
            }
        }

        public async Task<ApiResponse> Update(ContentFileDto fileDto)
        {
            try
            {
                return new ApiResponse(Status200OK, "Updated contentFile", await _contentFileStore.Update(fileDto));
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update contentFile");
            }
        }
    }
}
