using AutoMapper;
using BlazorBoilerplate.Shared.DataInterfaces;
using BlazorBoilerplate.Shared.DataModels;
using BlazorBoilerplate.Shared.Dto.Blog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Storage.Stores
{
    public class QuizStore : IQuizStore
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _autoMapper;

        public QuizStore(IApplicationDbContext db, IMapper autoMapper)
        {
            _db = db;
            _autoMapper = autoMapper;
        }
        public async Task<Quiz> Create(QuizDto quizDto)
        {
            var quiz = _autoMapper.Map<QuizDto, Quiz>(quizDto);
            await _db.Quizzes.AddAsync(quiz);
            await _db.QuizItems.AddRangeAsync(quiz.Items);
            await _db.SaveChangesAsync(CancellationToken.None);

            return quiz;
        }

        public async Task DeleteById(long id)
        {
            var items = _db.QuizItems.Where(t => t.QuizId == id).ToList();
            //if (items != null)
            //{
            //    _db.QuizItems.RemoveRange(items);
            //    _db.SaveChanges();
            //}

            _db.Quizzes.Remove(await _db.Quizzes.SingleOrDefaultAsync(t => t.Id == id));
            await _db.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<List<QuizDto>> GetAllByCourseId(long id)
        {
            var quizzes = await _autoMapper.ProjectTo<QuizDto>(_db.Quizzes.Include(x => x.Items).Where(x => x.CourseId == id)).ToListAsync();
            return quizzes;
        }

        public async Task<QuizDto> GetById(long id)
        {
            var quiz = await _db.Quizzes.Include(t => t.Items).SingleOrDefaultAsync(t => t.Id == id);
            //var items = _db.QuizItems.Where(s => s.QuizId == id).ToList();
            if (quiz == null)
                throw new InvalidDataException($"Unable to find Quiz with ID: {id}");

            //quiz.Items = items;
            return _autoMapper.Map<QuizDto>(quiz);
        }

        public async Task<Quiz> Update(QuizDto quizDto)
        {
            var quiz = await _db.Quizzes.SingleOrDefaultAsync(t => t.Id == quizDto.Id);
            if (quiz == null)
                throw new InvalidDataException($"Unable to find Quiz with ID: {quizDto.Id}");

            quiz = _autoMapper.Map(quizDto, quiz);
            _db.Quizzes.Update(quiz);
            //_db.QuizItems.UpdateRange(quiz.Items);
            await _db.SaveChangesAsync(CancellationToken.None);

            return quiz;
        }
    }
}
