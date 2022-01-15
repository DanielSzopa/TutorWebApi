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
        public DbSet<Like> Likes { get; set; }
        public TutorWebApiDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region 
            var subjects = new List<Subject>()
            {
                new Subject { Id = 1, Name = "Polish" },
                new Subject { Id = 2, Name = "English" },
                new Subject { Id = 3, Name = "French" },
                new Subject { Id = 4, Name = "German" },
                new Subject { Id = 5, Name = "Front-end Programming" },
                new Subject { Id = 6, Name = "Back-End Programming" },
                new Subject { Id = 7, Name = "Database" },
                new Subject { Id = 8, Name = "Maths" },
                new Subject { Id = 9, Name = "Physics" },
                new Subject { Id = 10, Name = "Chemistry" },
                new Subject { Id = 11, Name = "Geography" },
                new Subject { Id = 12, Name = "History" },
                new Subject { Id = 13, Name = "Science" },
                new Subject { Id = 14, Name = "Art" },
                new Subject { Id = 15, Name = "It" },
                new Subject { Id = 16, Name = "Technology" },
                new Subject { Id = 17, Name = "Business Studies" }
            };
            #endregion

            modelBuilder.Entity<Subject>()
                .HasData(subjects);

            modelBuilder.Entity<Achievement>()
                .Property(a => a.Name)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Achievement>()
                .Property(a => a.ProfilId)
                .IsRequired();

            modelBuilder.Entity<Address>()
               .Property(a => a.Country)
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder.Entity<Address>()
               .Property(a => a.City)
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder.Entity<Address>()
               .Property(a => a.UserRef)
               .IsRequired();

            modelBuilder.Entity<Advert>()
               .Property(a => a.Title)
               .HasMaxLength(150)
               .IsRequired();

            modelBuilder.Entity<Advert>()
               .Property(a => a.City)
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder.Entity<Advert>()
              .Property(a => a.ProfileId)
              .IsRequired();

            modelBuilder.Entity<Advert>()
              .Property(a => a.SubjectId)
              .IsRequired();

            modelBuilder.Entity<AdvertContact>()
              .Property(ac => ac.AdvertRef)
              .IsRequired();

            modelBuilder.Entity<AdvertContact>()
             .Property(ac => ac.Mail)
             .HasMaxLength(100)
             .IsRequired();

            modelBuilder.Entity<Comment>()
              .Property(c => c.Description)
              .IsRequired();

            modelBuilder.Entity<Comment>()
              .Property(c => c.ProfileId)
              .IsRequired();

            modelBuilder.Entity<Comment>()
             .Property(c => c.UserId)
             .IsRequired();

            modelBuilder.Entity<Experience>()
              .Property(e => e.ProfileId)
              .IsRequired();

            modelBuilder.Entity<Experience>()
              .Property(e => e.Name)
              .HasMaxLength(150)
              .IsRequired();

            modelBuilder.Entity<Like>()
              .Property(l => l.UserId)
              .IsRequired();

            modelBuilder.Entity<Like>()
              .Property(l => l.ProfileId)
              .IsRequired();

            modelBuilder.Entity<Profile>()
             .Property(p => p.UserRef)
             .IsRequired();

            modelBuilder.Entity<Subject>()
             .Property(s => s.Name)
             .HasMaxLength(50)
             .IsRequired();

            modelBuilder.Entity<User>()
             .Property(u => u.FirstName)
             .HasMaxLength(25)
             .IsRequired();

            modelBuilder.Entity<User>()
             .Property(u => u.LastName)
             .HasMaxLength(25)
             .IsRequired();

            modelBuilder.Entity<User>()
            .Property(u => u.Mail)
            .HasMaxLength(100)
            .IsRequired();

            modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .IsRequired();

            modelBuilder.Entity<User>()
            .Property(u => u.DateOfBirth)
            .IsRequired();

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

            modelBuilder.Entity<Like>()
                .HasKey(l => new { l.UserId, l.ProfileId });

            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
               .HasOne(l => l.Profile)
               .WithMany(p => p.Likes)
               .HasForeignKey(l => l.ProfileId);

        }

    }
}
