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
    public class QuizItemManager : IQuizItemManager
    {
        private readonly IQuizItemStore _quizItemStore;

        public QuizItemManager(IQuizItemStore quizItemStore)
        {
            _quizItemStore = quizItemStore;
        }

        public async Task<ApiResponse> Create(QuizItemDto quizItemDto)
        {
            var quizItem = await _quizItemStore.Create(quizItemDto);
            return new ApiResponse(Status200OK, "Created QuizItem", quizItem);
        }

        public async Task<ApiResponse> CreateRange(List<QuizItemDto> quizItemDtos)
        {
            var quizItems = await _quizItemStore.CreateRange(quizItemDtos);
            return new ApiResponse(Status200OK, "Created QuizItems", quizItems);
        }

        public async Task<ApiResponse> Delete(long id)
        {
            try
            {
                await _quizItemStore.DeleteById(id);
                return new ApiResponse(Status200OK, "Soft Delete QuizItem");
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update QuizItem");
            }
        }

        public async Task<ApiResponse> Get(long id)
        {
            try
            {
                return new ApiResponse(Status200OK, "Retrieved QuizItems", await _quizItemStore.GetAllByQuizId(id));
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
                return new ApiResponse(Status200OK, "Retrieved QuizItem", await _quizItemStore.GetById(id));
            }
            catch (Exception e)
            {
                return new ApiResponse(Status400BadRequest, "Failed to Retrieve QuizItem");
            }
        }

        public async Task<ApiResponse> Update(QuizItemDto quizItemDto)
        {
            try
            {
                return new ApiResponse(Status200OK, "Updated QuizItem", await _quizItemStore.Update(quizItemDto));
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update QuizItem");
            }
        }
    }
}
