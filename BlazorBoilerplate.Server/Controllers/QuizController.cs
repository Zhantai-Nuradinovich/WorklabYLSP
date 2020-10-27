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
    public class QuizController : ControllerBase
    {
        private readonly IQuizManager _quizManager;

        public QuizController(IQuizManager quizManager)
        {
            _quizManager = quizManager;
        }

        // GET: api/Quiz/course/5
        [HttpGet("course/{id}")]
        [Authorize]
        public async Task<ApiResponse> Get(long id)
            => await _quizManager.Get(id);

        // GET: api/Quiz/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ApiResponse> GetOne(int id)
            => ModelState.IsValid ?
                await _quizManager.GetOne(id) :
                new ApiResponse(Status400BadRequest, "Quiz Model is Invalid");

        // POST: api/Quiz
        [HttpPost]
        [Authorize(Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Post([FromBody] QuizDto quiz)
            => ModelState.IsValid ?
                await _quizManager.Create(quiz) :
                new ApiResponse(Status400BadRequest, "Quiz Model is Invalid");

        // Put: api/Quiz
        [HttpPut]
        [Authorize(Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Put([FromBody] QuizDto quiz)
            => ModelState.IsValid ?
                await _quizManager.Update(quiz) :
                new ApiResponse(Status400BadRequest, "Quiz Model is Invalid");

        // DELETE: api/Quiz/5
        [HttpDelete("{id}")]
        [Authorize(Permissions.Quiz.Delete, Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Delete(long id)
            => await _quizManager.Delete(id);
    }
}
