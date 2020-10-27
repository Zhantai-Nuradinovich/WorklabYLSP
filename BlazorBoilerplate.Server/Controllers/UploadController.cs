using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.Dto.Blog;
using BlazorBoilerplate.Storage;
using BlazorBoilerplate.Storage.Stores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BlazorBoilerplate.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext appContext;
        private IHostApplicationLifetime applicationLifetime;

        public UploadController(IWebHostEnvironment environment,
            ApplicationDbContext context,
            IHostApplicationLifetime appLifetime)
        {
            this.environment = environment;
            this.appContext = context;
            this.applicationLifetime = appLifetime;
        }

        #region public async Task<IActionResult> MultipleAsync(IFormFile[] files, string CurrentDirectory)    
        [HttpPost("[action]")]
        public async Task<IActionResult> MultipleAsync(
            IFormFile[] files, string CurrentDirectory)
        {
            try
            {
                if (HttpContext.Request.Form.Files.Any())
                {
                    foreach (var file in HttpContext.Request.Form.Files)
                    {
                        // reconstruct the path to ensure everything 
                        // goes to uploads directory
                        string RequestedPath =
                            CurrentDirectory.ToLower()
                            .Replace(environment.WebRootPath.ToLower(), "");

                        if (RequestedPath.Contains("\\uploads\\"))
                        {
                            RequestedPath =
                                RequestedPath.Replace("\\uploads\\", "");
                        }
                        else
                        {
                            RequestedPath = "";
                        }

                        string path =
                            Path.Combine(
                                environment.WebRootPath,
                                "uploads",
                                RequestedPath,
                                file.FileName);

                        using (var stream =
                            new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region public async Task<IActionResult> SingleAsync(IFormFile file, string FileTitle)
        [HttpPost("[action]")]
        public async Task<IActionResult> SingleAsync(
            IFormFile file, string FileTitle)
        {
            try
            {
                if (HttpContext.Request.Form.Files.Any())
                {
                    // Only accept .zip files
                    if (file.ContentType == "application/x-zip-compressed")
                    {
                        string path =
                            Path.Combine(
                                environment.WebRootPath,
                                "files",
                                file.FileName);

                        // Create directory if not exists
                        string directoryName = Path.GetDirectoryName(path);
                        if (!Directory.Exists(directoryName))
                        {
                            Directory.CreateDirectory(directoryName);
                        }

                        using (var stream =
                            new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        // Save to database
                        if (FileTitle == "")
                        {
                            FileTitle = "[Unknown]";
                        }

                        ContentFileDto objFilesDTO = new ContentFileDto();
                        objFilesDTO.ContentFileName = FileTitle;
                        objFilesDTO.ContentFilePath = file.FileName;
                    }
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        [HttpPost("[action]")]
        public async Task<IActionResult> UpgradeAsync(
            IFormFile file, string FileTitle)
        {
            try
            {
                if (HttpContext.Request.Form.Files.Any())
                {
                    // Only accept .zip files
                    if (file.ContentType == "application/x-zip-compressed")
                    {
                        string UploadPath =
                            Path.Combine(
                                environment.ContentRootPath,
                                "Uploads");

                        string UploadPathAndFile =
                            Path.Combine(
                                environment.ContentRootPath,
                                "Uploads",
                                "BlazorBlogsUpgrade.zip");

                        string UpgradePath = Path.Combine(
                            environment.ContentRootPath,
                            "Upgrade");

                        // Upload Upgrade package to Upload Folder
                        if (!Directory.Exists(UpgradePath))
                        {
                            Directory.CreateDirectory(UpgradePath);
                        }

                        using (var stream =
                            new FileStream(UploadPathAndFile, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        DeleteFiles(UpgradePath);

                        // Unzip files to Upgrade folder
                        ZipFile.ExtractToDirectory(UploadPathAndFile, UpgradePath, true);

                        // Proceed with upgrade...

                        DeleteFiles(UpgradePath);

                        // Unzip files to final paths
                        ZipFile.ExtractToDirectory(UploadPathAndFile, environment.ContentRootPath, true);

                        Task.Delay(4000).Wait(); // Wait 4 seconds with blocking
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok();
        }


        // Upgrade Code

        #region private static void DeleteFiles(string FilePath)
        private static void DeleteFiles(string FilePath)
        {
            if (System.IO.Directory.Exists(FilePath))
            {
                DirectoryInfo Directory = new DirectoryInfo(FilePath);
                Directory.Delete(true);
                Directory.Create();
            }
        }
        #endregion

        #region private int ConvertToInteger(string strParamVersion)
        private int ConvertToInteger(string strParamVersion)
        {
            int intVersionNumber = 0;
            string strVersion = strParamVersion;

            // Split into parts seperated by periods
            char[] splitchar = { '.' };
            var strSegments = strVersion.Split(splitchar);

            // Process the segments
            int i = 0;
            List<int> colMultiplyers = new List<int> { 10000, 100, 1 };
            foreach (var strSegment in strSegments)
            {
                int intSegmentNumber = Convert.ToInt32(strSegment);
                intVersionNumber = intVersionNumber + (intSegmentNumber * colMultiplyers[i]);
                i++;
            }

            return intVersionNumber;
        }
        #endregion
    }
}
