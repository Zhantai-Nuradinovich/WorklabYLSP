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
    public class ScienceDirectionStore : IScienceDirectionStore
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _autoMapper;

        public ScienceDirectionStore(IApplicationDbContext db, IMapper autoMapper)
        {
            _db = db;
            _autoMapper = autoMapper;
        }
        public async Task<ScienceDirection> Create(ScienceDirectionDto scienceDirectionDto)
        {
            var scienceDirection = _autoMapper.Map<ScienceDirectionDto, ScienceDirection>(scienceDirectionDto);
            await _db.ScienceDirections.AddAsync(scienceDirection);
            await _db.SaveChangesAsync(CancellationToken.None);

            return scienceDirection;
        }

        public async Task DeleteById(long id)
        {
            var courses = _db.Courses.Where(t => t.ScienceDirectionId == id).ToList();
            var files = new List<ContentFile>();
            var texts = new List<Text>();
            var quizzes = new List<Quiz>();

            foreach (var course in courses)
            {
                files.AddRange(_db.Files.Where(x => x.CourseId == course.CourseId));
                texts.AddRange(_db.Texts.Where(x => x.CourseId == course.CourseId));
                quizzes.AddRange(_db.Quizzes.Where(x => x.CourseId == course.CourseId));
            }

            var quizItems = new List<QuizItem>();

            foreach (var quiz in quizzes)
            {
                quizItems.AddRange(_db.QuizItems.Where(x => x.QuizId == quiz.Id));
            }

            if (quizItems != null)
            {
                _db.QuizItems.RemoveRange(quizItems);
                _db.SaveChanges();
            }

            if (quizzes != null)
            {
                _db.Quizzes.RemoveRange(quizzes);
                _db.SaveChanges();
            }

            if (texts != null)
            {
                _db.Texts.RemoveRange(texts);
                _db.SaveChanges();
            }

            if (files != null)
            {
                _db.Files.RemoveRange(files);
                _db.SaveChanges();
            }

            if (courses != null)
            {
                _db.Courses.RemoveRange(courses);
                _db.SaveChanges();
            }

            _db.ScienceDirections.Remove(await _db.ScienceDirections.SingleOrDefaultAsync(t => t.ScienceDirectionId == id));
            await _db.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<List<ScienceDirectionDto>> GetAll()
        {
            var scienceDirections = await _autoMapper.ProjectTo<ScienceDirectionDto>(_db.ScienceDirections).OrderBy(i => i.Title).ToListAsync();
            return scienceDirections;
        }

        public async Task<ScienceDirectionDto> GetById(long id)
        {
            var scienceDirection = await _db.ScienceDirections.SingleOrDefaultAsync(t => t.ScienceDirectionId == id);
            if (scienceDirection == null)
                throw new InvalidDataException($"Unable to find ScienceDirection with ID: {id}");

            return _autoMapper.Map<ScienceDirectionDto>(scienceDirection);
        }

        public async Task<ScienceDirection> Update(ScienceDirectionDto scienceDirectionDto)
        {
            var scienceDirection = await _db.ScienceDirections.SingleOrDefaultAsync(t => t.ScienceDirectionId == scienceDirectionDto.ScienceDirectionId);
            if (scienceDirection == null)
                throw new InvalidDataException($"Unable to find ScienceDirection with ID: {scienceDirectionDto.ScienceDirectionId}");

            scienceDirection = _autoMapper.Map(scienceDirectionDto, scienceDirection);
            _db.ScienceDirections.Update(scienceDirection);
            await _db.SaveChangesAsync(CancellationToken.None);

            return scienceDirection;
        }
    }
}
