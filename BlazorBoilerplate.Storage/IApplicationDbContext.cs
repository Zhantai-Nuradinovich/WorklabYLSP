using BlazorBoilerplate.Server.Models;
using BlazorBoilerplate.Shared.DataInterfaces;
using BlazorBoilerplate.Shared.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Storage
{
    public interface IApplicationDbContext
    {
        public DbSet<ApiLogItem> ApiLogs { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        //public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizItem> QuizItems { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Text> Texts { get; set; }
        public void SetGlobalQueryForSoftDelete<T>(ModelBuilder builder) where T : class, ISoftDelete;

        public void SetGlobalQueryForSoftDeleteAndTenant<T>(ModelBuilder builder) where T : class, ISoftDelete, ITenant;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();

    }
}
