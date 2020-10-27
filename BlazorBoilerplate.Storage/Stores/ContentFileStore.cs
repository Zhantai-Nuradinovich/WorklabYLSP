using AutoMapper;
using BlazorBoilerplate.Shared.DataInterfaces;
using BlazorBoilerplate.Shared.DataModels;
using BlazorBoilerplate.Shared.Dto.Blog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Storage.Stores
{
    public class ContentFileStore : IContentFileStore
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _autoMapper;

        public ContentFileStore(IApplicationDbContext db, IMapper autoMapper)
        {
            _db = db;
            _autoMapper = autoMapper;
        }
        public async Task<ContentFile> Create(ContentFileDto contentFileDto)
        {
            var file = _autoMapper.Map<ContentFileDto, ContentFile>(contentFileDto);
            await _db.Files.AddAsync(file);
            await _db.SaveChangesAsync(CancellationToken.None);

            return file;
        }

        public async Task DeleteById(long id)
        {
            _db.Files.Remove(await _db.Files.SingleOrDefaultAsync(t => t.ContentFileId == id));
            await _db.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<List<ContentFileDto>> GetAllByCourseId(long id)
        {
            var files = await _autoMapper.ProjectTo<ContentFileDto>(_db.Files.Where(x => x.CourseId == id)).ToListAsync();
            return files;
        }

        public async Task<ContentFileDto> GetById(long id)
        {
            var file = await _db.Files.SingleOrDefaultAsync(t => t.CourseId == id);
            if (file == null)
                throw new InvalidDataException($"Unable to find File with ID: {id}");

            return _autoMapper.Map<ContentFileDto>(file);
        }

        public async Task<ContentFile> Update(ContentFileDto contentFileDto)
        {
            var file = await _db.Files.SingleOrDefaultAsync(t => t.CourseId == contentFileDto.CourseId);
            if (file == null)
                throw new InvalidDataException($"Unable to find File with ID: {contentFileDto.CourseId}");

            file = _autoMapper.Map(contentFileDto, file);
            _db.Files.Update(file);
            await _db.SaveChangesAsync(CancellationToken.None);

            return file;
        }
    }
}
