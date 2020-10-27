using BlazorBoilerplate.Shared.DataModels;
using BlazorBoilerplate.Shared.Dto.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Shared.DataInterfaces
{
    public interface ICourseStore
    {
        Task<List<CourseDto>> GetAll();
        Task<CourseDto> GetById(long id);
        Task<Course> Create(CourseDto courseDto);
        Task<Course> Update(CourseDto courseDto);
        Task DeleteById(long id);
    }
}
