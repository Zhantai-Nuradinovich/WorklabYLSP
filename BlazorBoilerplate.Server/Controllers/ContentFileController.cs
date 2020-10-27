using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorBoilerplate.Server.Managers;
using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.AuthorizationDefinitions;
using BlazorBoilerplate.Shared.Dto.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace BlazorBoilerplate.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentFileController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        private readonly IContentFileManager _contentFileManager;
        public ContentFileController(IWebHostEnvironment environment, IContentFileManager contentFileManager)
        {
            this.environment = environment;
            _contentFileManager = contentFileManager;
        }

        [HttpGet("[action]")]
        public IActionResult DownloadFile(string FileName)
        {
            string path = Path.Combine(
                                environment.WebRootPath,
                                "files",
                                FileName);

            var stream = new FileStream(path, FileMode.Open);

            var result = new FileStreamResult(stream, "text/plain");
            result.FileDownloadName = FileName;
            return result;
        }

        // This cannot be called by an API call
        public void DeleteFile(string FileName)
        {
            string path = Path.Combine(
                                environment.WebRootPath,
                                "files",
                                FileName);

            if (System.IO.File.Exists(path))
            {
                // If file found, delete it    
                System.IO.File.Delete(path);
            }
        }

        // GET: api/contentFile/course/5
        [HttpGet("course/{id}")]
        [Authorize]
        public async Task<ApiResponse> Get(long id)
            => await _contentFileManager.Get(id);

        // GET: api/contentFile/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ApiResponse> GetOne(int id)
            => ModelState.IsValid ?
                await _contentFileManager.GetOne(id) :
                new ApiResponse(Status400BadRequest, "contentFile Model is Invalid");

        // POST: api/contentFile
        [HttpPost]
        [Authorize(Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Post([FromBody] ContentFileDto contentFile)
            => ModelState.IsValid ?
                await _contentFileManager.Create(contentFile) :
                new ApiResponse(Status400BadRequest, "ContentFile Model is Invalid");

        // Put: api/contentFile
        [HttpPut]
        [Authorize(Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Put([FromBody] ContentFileDto contentFile)
            => ModelState.IsValid ?
                await _contentFileManager.Update(contentFile) :
                new ApiResponse(Status400BadRequest, "contentFile Model is Invalid");

        // DELETE: api/contentFile/5
        [HttpDelete("{id}")]
        [Authorize(Permissions.ContentFile.Delete, Roles = "Administrator, Coordinator")]
        public async Task<ApiResponse> Delete(long id)
            => await _contentFileManager.Delete(id);
    }
}
