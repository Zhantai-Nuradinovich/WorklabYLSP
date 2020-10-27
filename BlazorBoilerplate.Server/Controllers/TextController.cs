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
    public class TextController : ControllerBase
    {
        private readonly ITextManager _textManager;

        public TextController(ITextManager textManager)
        {
            _textManager = textManager;
        }

        // GET: api/text/course/5
        [HttpGet("course/{id}")]
        [Authorize]
        public async Task<ApiResponse> Get(long id)
            => await _textManager.Get(id);

        // GET: api/text/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ApiResponse> GetOne(int id)
            => ModelState.IsValid ?
                await _textManager.GetOne(id) :
                new ApiResponse(Status400BadRequest, "Text Model is Invalid");

        // POST: api/text
        [HttpPost]
        [Authorize(Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Post([FromBody] TextDto text)
            => ModelState.IsValid ?
                await _textManager.Create(text) :
                new ApiResponse(Status400BadRequest, "Text Model is Invalid");

        // Put: api/text
        [HttpPut]
        [Authorize(Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Put([FromBody] TextDto text)
            => ModelState.IsValid ?
                await _textManager.Update(text) :
                new ApiResponse(Status400BadRequest, "Text Model is Invalid");

        // DELETE: api/text/5
        [HttpDelete("{id}")]
        [Authorize(Permissions.Text.Delete, Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Delete(long id)
            => await _textManager.Delete(id);
    }
}
