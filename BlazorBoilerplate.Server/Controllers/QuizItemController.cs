using BlazorBoilerplate.Server.Managers;
using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.AuthorizationDefinitions;
using BlazorBoilerplate.Shared.Dto.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace BlazorBoilerplate.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuizItemController : ControllerBase
    {
        private readonly IQuizItemManager _quizItemManager;

        public QuizItemController(IQuizItemManager quizItemManager)
        {
            _quizItemManager = quizItemManager;
        }

        // GET: api/QuizItem/quiz/5
        [HttpGet("quiz/{id}")]
        [Authorize]
        public async Task<ApiResponse> Get(long id)
            => await _quizItemManager.Get(id);

        // GET: api/QuizItem/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ApiResponse> GetOne(int id)
            => ModelState.IsValid ?
                await _quizItemManager.GetOne(id) :
                new ApiResponse(Status400BadRequest, "QuizItem Model is Invalid");

        // POST: api/QuizItem
        [HttpPost]
        [Authorize(Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Post([FromBody] QuizItemDto quizItem)
            => ModelState.IsValid ?
                await _quizItemManager.Create(quizItem) :
                new ApiResponse(Status400BadRequest, "QuizItem Model is Invalid");

        // Put: api/QuizItem
        [HttpPut]
        [Authorize(Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Put([FromBody] QuizItemDto quizItem)
            => ModelState.IsValid ?
                await _quizItemManager.Update(quizItem) :
                new ApiResponse(Status400BadRequest, "QuizItem Model is Invalid");

        // DELETE: api/QuizItem/5
        [HttpDelete("{id}")]
        [Authorize(Permissions.Quiz.Delete, Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Delete(long id)
            => await _quizItemManager.Delete(id);
    }
}
