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
    public class CourseStore : ICourseStore
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _autoMapper;

        public CourseStore(IApplicationDbContext db, IMapper autoMapper)
        {
            _db = db;
            _autoMapper = autoMapper;
        }
        public async Task<Course> Create(CourseDto courseDto)
        {
            var course = _autoMapper.Map<CourseDto, Course>(courseDto);
            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync(CancellationToken.None);

            return course;
        }

        public async Task DeleteById(long id)
        {
            //var texts = _db.Texts.Where(t => t.CourseId == id).ToList();
            //var quizzes = _db.Quizzes.Where(t => t.CourseId == id).ToList();
            //var quizItems = new List<QuizItem>();

            //foreach (var quiz in quizzes)
            //{
            //    quizItems.AddRange(_db.QuizItems.Where(x => x.QuizId == quiz.Id));
            //}

            //if (quizItems != null)
            //{
            //    _db.QuizItems.RemoveRange(quizItems);
            //    _db.SaveChanges();
            //}

            //if(quizzes != null)
            //{
            //    _db.Quizzes.RemoveRange(quizzes);
            //    _db.SaveChanges();
            //}

            //if(texts != null)
            //{
            //    _db.Texts.RemoveRange(texts);
            //    _db.SaveChanges();
            //}

            _db.Courses.Remove(await _db.Courses.SingleOrDefaultAsync(t => t.CourseId == id));
            await _db.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<List<CourseDto>> GetAll()
        {
            var courses = await _autoMapper.ProjectTo<CourseDto>(_db.Courses).OrderBy(i => i.CourseName).ToListAsync();
            return courses;
        }

        public async Task<CourseDto> GetById(long id)
        {
            var course = await _db.Courses.Include(t => t.Quizzes).Include(t => t.Texts).SingleOrDefaultAsync(t => t.CourseId == id);
            if (course == null)
                throw new InvalidDataException($"Unable to find Course with ID: {id}");

            return _autoMapper.Map<CourseDto>(course);
        }

        public async Task<Course> Update(CourseDto courseDto)
        {
            var course = await _db.Courses.SingleOrDefaultAsync(t => t.CourseId == courseDto.CourseId);
            if (course == null)
                throw new InvalidDataException($"Unable to find Course with ID: {courseDto.CourseId}");

            course = _autoMapper.Map(courseDto, course);
            _db.Courses.Update(course);
            await _db.SaveChangesAsync(CancellationToken.None);

            return course;
        }
    }
}
