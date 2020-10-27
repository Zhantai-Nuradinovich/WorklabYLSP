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
    public class QuizItemStore : IQuizItemStore
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _autoMapper;

        public QuizItemStore(IApplicationDbContext db, IMapper autoMapper)
        {
            _db = db;
            _autoMapper = autoMapper;
        }
        public async Task<QuizItem> Create(QuizItemDto quizItemDto)
        {
            var quizItem = _autoMapper.Map<QuizItemDto, QuizItem>(quizItemDto);
            await _db.QuizItems.AddAsync(quizItem);
            await _db.SaveChangesAsync(CancellationToken.None);

            return quizItem;
        }

        public async Task<List<QuizItem>> CreateRange(List<QuizItemDto> quizItemDtos)
        {
            var quizItems = _autoMapper.Map<List<QuizItemDto>, List<QuizItem>>(quizItemDtos);
            await _db.QuizItems.AddRangeAsync(quizItems);
            await _db.SaveChangesAsync(CancellationToken.None);

            return quizItems;
        }

        public async Task DeleteById(long id)
        {
            _db.QuizItems.Remove(await _db.QuizItems.SingleOrDefaultAsync(t => t.Id == id));
            await _db.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<QuizItemDto> GetById(long id)
        {
            var quizItem = await _db.QuizItems.SingleOrDefaultAsync(t => t.Id == id);
            if (quizItem == null)
                throw new InvalidDataException($"Unable to find QuizItem with ID: {id}");

            return _autoMapper.Map<QuizItemDto>(quizItem);
        }

        public async Task<QuizItem> Update(QuizItemDto quizItemDto)
        {
            var quizItem = await _db.QuizItems.SingleOrDefaultAsync(t => t.Id == quizItemDto.Id);
            if (quizItem == null)
                throw new InvalidDataException($"Unable to find QuizItem with ID: {quizItemDto.Id}");

            quizItem = _autoMapper.Map(quizItemDto, quizItem);
            _db.QuizItems.Update(quizItem);
            await _db.SaveChangesAsync(CancellationToken.None);

            return quizItem;
        }

        public async Task<List<QuizItemDto>> GetAllByQuizId(long id)
        {
            var quizItems = await _autoMapper.ProjectTo<QuizItemDto>(_db.QuizItems.Where(x => x.QuizId == id)).ToListAsync();
            return quizItems;
        }
    }
}
