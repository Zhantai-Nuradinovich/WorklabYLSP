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
    public class ScienceDirectionManager : IScienceDirectionManager
    {
        private readonly IScienceDirectionStore _scienceDirectionStore;

        public ScienceDirectionManager(IScienceDirectionStore scienceDirectionStore)
        {
            _scienceDirectionStore = scienceDirectionStore;
        }
        public async Task<ApiResponse> Create(ScienceDirectionDto scienceDirectionDto)
        {
            var scienceDirection = await _scienceDirectionStore.Create(scienceDirectionDto);
            return new ApiResponse(Status200OK, "Created ScirenceDirection", scienceDirection);
        }

        public async Task<ApiResponse> Delete(long id)
        {
            try
            {
                await _scienceDirectionStore.DeleteById(id);
                return new ApiResponse(Status200OK, "Soft Delete ScienceDirection");
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update ScienceDirection");
            }
        }

        public async Task<ApiResponse> Get()
        {
            try
            {
                return new ApiResponse(Status200OK, "Retrieved ScienceDirections", await _scienceDirectionStore.GetAll());
            }
            catch (Exception ex)
            {
                return new ApiResponse(Status400BadRequest, ex.Message);
            }
        }

        public async Task<ApiResponse> Get(long id)
        {
            try
            {
                return new ApiResponse(Status200OK, "Retrieved ScienceDirections", await _scienceDirectionStore.GetById(id));
            }
            catch (Exception ex)
            {
                return new ApiResponse(Status400BadRequest, ex.Message);
            }
        }

        public async Task<ApiResponse> Update(ScienceDirectionDto scienceDirectionDto)
        {
            try
            {
                return new ApiResponse(Status200OK, "Updated ScienceDirection", await _scienceDirectionStore.Update(scienceDirectionDto));
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update ScienceDirection");
            }
        }
    }
}
