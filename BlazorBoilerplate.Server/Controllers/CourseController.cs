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
    public class CourseController : ControllerBase
    {
        private readonly ICourseManager _courseManager;

        public CourseController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        // GET: api/course/
        [HttpGet]
        [Authorize]
        public async Task<ApiResponse> Get()
            => await _courseManager.Get();

        // GET: api/course/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ApiResponse> GetOne(int id)
            => ModelState.IsValid ?
                await _courseManager.GetOne(id) :
                new ApiResponse(Status400BadRequest, "Course Model is Invalid");

        // POST: api/course
        [HttpPost]
        [Authorize(Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Post([FromBody] CourseDto course)
            => ModelState.IsValid ?
                await _courseManager.Create(course) :
                new ApiResponse(Status400BadRequest, "Course Model is Invalid");

        // Put: api/course
        [HttpPut]
        [Authorize(Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Put([FromBody] CourseDto course)
            => ModelState.IsValid ?
                await _courseManager.Update(course) :
                new ApiResponse(Status400BadRequest, "Course Model is Invalid");

        // DELETE: api/course/5
        [HttpDelete("{id}")]
        [Authorize(Permissions.Course.Delete, Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Delete(long id)
            => await _courseManager.Delete(id);
    }
}
