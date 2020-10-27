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
    public class ScienceDirectionController : ControllerBase
    {
        private readonly IScienceDirectionManager _scienceDirectionManager;

        public ScienceDirectionController(IScienceDirectionManager scienceDirectionManager)
        {
            _scienceDirectionManager = scienceDirectionManager;
        }

        // GET: api/scienceDirection
        [HttpGet]
        [Authorize]
        public async Task<ApiResponse> Get()
            => await _scienceDirectionManager.Get();

        // GET: api/scienceDirection/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ApiResponse> GetOne(int id)
            => ModelState.IsValid ?
                await _scienceDirectionManager.Get(id) :
                new ApiResponse(Status400BadRequest, "ScienceDirection Model is Invalid");

        // POST: api/scienceDirection
        [HttpPost]
        [Authorize(Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Post([FromBody] ScienceDirectionDto scienceDirection)
            => ModelState.IsValid ?
                await _scienceDirectionManager.Create(scienceDirection) :
                new ApiResponse(Status400BadRequest, "ScienceDirection Model is Invalid");

        // Put: api/scienceDirection
        [HttpPut]
        [Authorize(Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Put([FromBody] ScienceDirectionDto scienceDirection)
            => ModelState.IsValid ?
                await _scienceDirectionManager.Update(scienceDirection) :
                new ApiResponse(Status400BadRequest, "ScienceDirection Model is Invalid");

        // DELETE: api/scienceDirection/5
        [HttpDelete("{id}")]
        [Authorize(Permissions.ScienceDirection.Delete, Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Delete(long id)
            => await _scienceDirectionManager.Delete(id);
    }
}
