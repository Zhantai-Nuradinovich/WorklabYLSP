using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.DataInterfaces;
using BlazorBoilerplate.Shared.Dto.Blog;
using static Microsoft.AspNetCore.Http.StatusCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace BlazorBoilerplate.Server.Managers
{
    public class TextManager : ITextManager
    {
        private readonly ITextStore _textStore;

        public TextManager(ITextStore textStore)
        {
            _textStore = textStore;
        }
        public async Task<ApiResponse> Create(TextDto textDto)
        {
            var text = await _textStore.Create(textDto);
            return new ApiResponse(Status200OK, "Created text", text);
        }

        public async Task<ApiResponse> Delete(long id)
        {
            try
            {
                await _textStore.DeleteById(id);
                return new ApiResponse(Status200OK, "Soft Delete text");
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update text");
            }
        }
        public async Task<ApiResponse> Get(long id)
        {
            try
            {
                return new ApiResponse(Status200OK, "Retrieved texts", await _textStore.GetAllByCourseId(id));
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
                return new ApiResponse(Status200OK, "Retrieved text", await _textStore.GetById(id));
            }
            catch (Exception e)
            {
                return new ApiResponse(Status400BadRequest, "Failed to Retrieve text");
            }
        }

        public async Task<ApiResponse> Update(TextDto textDto)
        {
            try
            {
                return new ApiResponse(Status200OK, "Updated text", await _textStore.Update(textDto));
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update text");
            }
        }
    }
}
