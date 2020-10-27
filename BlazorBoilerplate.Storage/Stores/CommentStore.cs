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
    public class CommentStore : ICommentStore
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _autoMapper;

        public CommentStore(IApplicationDbContext db, IMapper autoMapper)
        {
            _db = db;
            _autoMapper = autoMapper;
        }

        public async Task<Comment> Create(CommentDto commentDto)
        {
            var comment = _autoMapper.Map<CommentDto, Comment>(commentDto);
            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync(CancellationToken.None);

            return comment;
        }

        public async Task DeleteById(long id)
        {
            _db.Comments.Remove(await _db.Comments.SingleOrDefaultAsync(t => t.CommentId == id));
            await _db.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<List<CommentDto>> GetAllByCourseId(long id)
        {
            var comments = await _autoMapper.ProjectTo<CommentDto>(_db.Comments.Where(x => x.CourseId == id)).OrderByDescending(i => i.When).ToListAsync();
            return comments;
        }

        public async Task<CommentDto> GetById(long id)
        {
            var comment = await _db.Comments.SingleOrDefaultAsync(t => t.CourseId == id);
            if (comment == null)
                throw new InvalidDataException($"Unable to find Comment with ID: {id}");

            return _autoMapper.Map<CommentDto>(comment);
        }

        public async Task<Comment> Update(CommentDto commentDto)
        {
            var comment = await _db.Comments.SingleOrDefaultAsync(t => t.CourseId == commentDto.CourseId);
            if (comment == null)
                throw new InvalidDataException($"Unable to find Comment with ID: {commentDto.CourseId}");

            comment = _autoMapper.Map(commentDto, comment);
            _db.Comments.Update(comment);
            await _db.SaveChangesAsync(CancellationToken.None);

            return comment;
        }
    }
}
