using Microsoft.EntityFrameworkCore;
using TutorWebApi.Domain.Common;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;
using TutorWebApi.Infrastructure.Config;

namespace TutorWebApi.Infrastructure.Context
{
    public class TutorWebApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdvertContact> AdvertContacts { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

        private readonly IUserContextService _userContextService;
        public TutorWebApiDbContext(DbContextOptions dbContextOptions, IUserContextService userContextService) : base(dbContextOptions)
        {
            _userContextService = userContextService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddAchievementConfig();
            modelBuilder.AddAddressConfig();
            modelBuilder.AddAdvertConfig();
            modelBuilder.AddAdvertContactConfig();
            modelBuilder.AddCommentConfig();
            modelBuilder.AddExperienceConfig();
            modelBuilder.AddLikeConfig();
            modelBuilder.AddProfileConfig();
            modelBuilder.AddSubjectConfig();
            modelBuilder.AddUserConfig();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken token = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateById = await _userContextService.GetUserId();
                        entry.Entity.CreateDate = DateTime.Now;
                        entry.Entity.IsActive = true;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifyById = await _userContextService.GetUserId();
                        entry.Entity.ModifyDate = DateTime.Now;
                        entry.Entity.IsActive = true;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifyById = await _userContextService.GetUserId();
                        entry.Entity.ModifyDate = DateTime.Now;
                        entry.Entity.IsActive = false;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return await base.SaveChangesAsync(token);
        }
    }
}
