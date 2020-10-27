using BlazorBoilerplate.Shared.DataModels;
using BlazorBoilerplate.Shared.Dto.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Shared.DataInterfaces
{
    public interface IContentFileStore
    {
        Task<List<ContentFileDto>> GetAllByCourseId(long id);

        Task<ContentFileDto> GetById(long id);

        Task<ContentFile> Create(ContentFileDto contentFileDto);

        Task<ContentFile> Update(ContentFileDto contentFileDto);
        Task DeleteById(long id);
    }
}
