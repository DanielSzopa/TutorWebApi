using Microsoft.EntityFrameworkCore;
using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Infrastructure.Config
{
    public static class ModelBuilderConfig
    {
        public static void AddAchievementConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Achievement>()
               .Property(a => a.Name)
               .HasMaxLength(150)
               .IsRequired();

            modelBuilder.Entity<Achievement>()
                .Property(a => a.ProfilId)
                .IsRequired();
        }

        public static void AddAddressConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
               .Property(a => a.Country)
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder.Entity<Address>()
               .Property(a => a.City)
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder.Entity<Address>()
              .Property(a => a.PosteCode)
              .HasMaxLength(10)
              .IsRequired();

            modelBuilder.Entity<Address>()
              .Property(a => a.Street)
              .HasMaxLength(60);

            modelBuilder.Entity<Address>()
             .Property(a => a.AccommodationNumber)
             .HasMaxLength(6);

            modelBuilder.Entity<Address>()
               .Property(a => a.UserRef)
               .IsRequired();
        }

        public static void AddAdvertConfig(this ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Advert>()
                .HasOne(a => a.AdvertContact)
                .WithOne(ac => ac.Advert)
                .HasForeignKey<AdvertContact>(ac => ac.AdvertRef);
        }

        public static void AddAdvertContactConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdvertContact>()
             .Property(ac => ac.AdvertRef)
             .IsRequired();

            modelBuilder.Entity<AdvertContact>()
             .Property(ac => ac.Mail)
             .HasMaxLength(100)
             .IsRequired();
        }

        public static void AddCommentConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
              .Property(c => c.Description)
              .IsRequired();

            modelBuilder.Entity<Comment>()
              .Property(c => c.ProfileId)
              .IsRequired();

            modelBuilder.Entity<Comment>()
             .Property(c => c.UserId)
             .IsRequired();

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

        public static void AddExperienceConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experience>()
                .Property(e => e.ProfileId)
                .IsRequired();

            modelBuilder.Entity<Experience>()
              .Property(e => e.Name)
              .HasMaxLength(150)
              .IsRequired();
        }

        public static void AddLikeConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>()
              .Property(l => l.UserId)
              .IsRequired();

            modelBuilder.Entity<Like>()
              .Property(l => l.ProfileId)
              .IsRequired();

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

        public static void AddProfileConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
             .Property(p => p.UserRef)
             .IsRequired();

            modelBuilder.Entity<Profile>()
                .HasOne(p => p.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<Profile>(p => p.UserRef);
        }

        public static void AddSubjectConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>()
             .Property(s => s.Name)
             .HasMaxLength(50)
             .IsRequired();
        }
        public static void AddUserConfig(this ModelBuilder modelBuilder)
        {
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
        }
    }
}
