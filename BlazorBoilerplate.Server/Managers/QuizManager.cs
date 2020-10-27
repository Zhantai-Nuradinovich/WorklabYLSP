using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.DataInterfaces;
using BlazorBoilerplate.Shared.Dto.Blog;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlazorBoilerplate.Server.Managers
{
    public class QuizManager : IQuizManager
    {
        private readonly IQuizStore _quizStore;
        public QuizManager(IQuizStore quizStore)
        {
            _quizStore = quizStore;
        }

        public async Task<ApiResponse> Get(long id)
        {
            try
            {
                return new ApiResponse(Status200OK, "Retrieved Quizzes", await _quizStore.GetAllByCourseId(id));
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
                var quiz = await _quizStore.GetById(id);
                return new ApiResponse(Status200OK, "Retrieved Quiz", quiz);
            }
            catch (Exception e)
            {
                return new ApiResponse(Status400BadRequest, "Failed to Retrieve Quiz");
            }
        }

        public async Task<ApiResponse> Create(QuizDto quizDto)
        {
            var quiz = await _quizStore.Create(quizDto);
            return new ApiResponse(Status200OK, "Created Quiz", quiz);
        }

        public async Task<ApiResponse> Update(QuizDto quizDto)
        {
            try
            {
                return new ApiResponse(Status200OK, "Updated Quiz", await _quizStore.Update(quizDto));
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update Quiz");
            }
        }

        public async Task<ApiResponse> Delete(long id)
        {
            try
            {
                await _quizStore.DeleteById(id);
                return new ApiResponse(Status200OK, "Soft Delete Quiz");
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update Quiz");
            }
        }
    }
}
