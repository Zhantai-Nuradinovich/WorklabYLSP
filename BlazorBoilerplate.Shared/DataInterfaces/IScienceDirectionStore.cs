using BlazorBoilerplate.Shared.DataModels;
using BlazorBoilerplate.Shared.Dto.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Shared.DataInterfaces
{
    public interface IScienceDirectionStore 
    { 
        Task<List<ScienceDirectionDto>> GetAll();

        Task<ScienceDirectionDto> GetById(long id);

        Task<ScienceDirection> Create(ScienceDirectionDto scienceDirectionDto);

        Task<ScienceDirection> Update(ScienceDirectionDto scienceDirectionDto);
        Task DeleteById(long id);
    }
}
