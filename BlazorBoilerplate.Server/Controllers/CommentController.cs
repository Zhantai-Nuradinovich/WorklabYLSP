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
    public class CommentController : ControllerBase
    {
        private readonly ICommentManager _commentManager;

        public CommentController(ICommentManager commentManager)
        {
            _commentManager = commentManager;
        }

        // GET: api/comment/course/5
        [HttpGet("course/{id}")]
        [Authorize]
        public async Task<ApiResponse> Get(long id)
            => await _commentManager.Get(id);

        // GET: api/comment/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ApiResponse> GetOne(int id)
            => ModelState.IsValid ?
                await _commentManager.GetOne(id) :
                new ApiResponse(Status400BadRequest, "Comment Model is Invalid");

        // POST: api/comment
        [HttpPost]
        [Authorize(Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Post([FromBody] CommentDto comment)
            => ModelState.IsValid ?
                await _commentManager.Create(comment) :
                new ApiResponse(Status400BadRequest, "Comment Model is Invalid");

        // Put: api/comment
        [HttpPut]
        [Authorize(Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Put([FromBody] CommentDto comment)
            => ModelState.IsValid ?
                await _commentManager.Update(comment) :
                new ApiResponse(Status400BadRequest, "Comment Model is Invalid");

        // DELETE: api/comment/5
        [HttpDelete("{id}")]
        [Authorize(Permissions.Text.Delete, Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Delete(long id)
            => await _commentManager.Delete(id);
    }
}
