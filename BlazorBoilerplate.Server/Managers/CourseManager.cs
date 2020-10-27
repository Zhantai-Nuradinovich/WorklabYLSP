using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.DataInterfaces;
using BlazorBoilerplate.Shared.Dto.Blog;
using static Microsoft.AspNetCore.Http.StatusCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace BlazorBoilerplate.Server.Managers
{
    public class CourseManager : ICourseManager
    {
        private readonly ICourseStore _courseStore;

        public CourseManager(ICourseStore courseStore)
        {
            _courseStore = courseStore;
        }

        public async Task<ApiResponse> Create(CourseDto courseDto)
        {
            var course = await _courseStore.Create(courseDto);
            return new ApiResponse(Status200OK, "Created Course", course);
        }

        public async Task<ApiResponse> Delete(long id)
        {
            try
            {
                await _courseStore.DeleteById(id);
                return new ApiResponse(Status200OK, "Soft Delete Course");
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update Course");
            }
        }

        //Gets all 
        public async Task<ApiResponse> Get()
        {
            try
            {
                return new ApiResponse(Status200OK, "Retrieved Coruses", await _courseStore.GetAll());
            }
            catch (Exception ex)
            {
                return new ApiResponse(Status400BadRequest, ex.Message);
            }
        }

        //Gets only one course by Id
        public async Task<ApiResponse> GetOne(long id)
        {
            try
            {
                return new ApiResponse(Status200OK, "Retrieved Course", await _courseStore.GetById(id));
            }
            catch (Exception e)
            {
                return new ApiResponse(Status400BadRequest, "Failed to Retrieve Course");
            }
        }

        public async Task<ApiResponse> Update(CourseDto courseDto)
        {
            try
            {
                return new ApiResponse(Status200OK, "Updated Course", await _courseStore.Update(courseDto));
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update Course");
            }
        }
    }
}
