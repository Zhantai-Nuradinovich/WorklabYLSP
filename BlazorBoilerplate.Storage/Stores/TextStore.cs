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
    public class TextStore : ITextStore
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _autoMapper;

        public TextStore(IApplicationDbContext db, IMapper autoMapper)
        {
            _db = db;
            _autoMapper = autoMapper;
        }
        public async Task<Text> Create(TextDto textDto)
        {
            var text = _autoMapper.Map<TextDto, Text>(textDto);
            await _db.Texts.AddAsync(text);
            await _db.SaveChangesAsync(CancellationToken.None);

            return text;
        }

        public async Task DeleteById(long id)
        {
            _db.Texts.Remove(await _db.Texts.SingleOrDefaultAsync(t => t.TextId == id));
            await _db.SaveChangesAsync(CancellationToken.None);
        }

        public async Task DeleteByCourseId(long id)
        {
            _db.Texts.RemoveRange(await _db.Texts.Where(t => t.CourseId == id).ToListAsync());
            await _db.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<TextDto> GetById(long id)
        {
            var text = await _db.Texts.SingleOrDefaultAsync(t => t.TextId == id);
            if (text == null)
                throw new InvalidDataException($"Unable to find Text with ID: {id}");

            return _autoMapper.Map<TextDto>(text);
        }

        public async Task<Text> Update(TextDto textDto)
        {
            var text = await _db.Texts.SingleOrDefaultAsync(t => t.TextId == textDto.TextId);
            if (text == null)
                throw new InvalidDataException($"Unable to find Text with ID: {textDto.TextId}");

            text = _autoMapper.Map(textDto, text);
            _db.Texts.Update(text);
            await _db.SaveChangesAsync(CancellationToken.None);

            return text;
        }

        public async Task<List<TextDto>> GetAllByCourseId(long id)
        {
            var texts = await _autoMapper.ProjectTo<TextDto>(_db.Texts.Where(x => x.CourseId == id)).ToListAsync();
            return texts;
        }
    }
}
