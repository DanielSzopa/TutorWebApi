using Microsoft.EntityFrameworkCore;
using TutorWebApi.Domain;

namespace TutorWebApi.Infrastructure
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
        public TutorWebApiDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserRef);

            modelBuilder.Entity<Advert>()
                .HasOne(a => a.AdvertContact)
                .WithOne(ac => ac.Advert)
                .HasForeignKey<AdvertContact>(ac => ac.AdvertRef);

            modelBuilder.Entity<Profile>()
                .HasOne(p => p.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<Profile>(p => p.UserRef);

            modelBuilder.Entity<Comment>()
                .HasKey(c => new { c.UserId, c.ProfileId });

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
               .HasOne(c => c.Profile)
               .WithMany(p => p.Comments)
               .HasForeignKey(c => c.ProfileId);

            
        }

    }
}
