using Microsoft.EntityFrameworkCore;
using NikamozzShop.Domain.Entites;

namespace NikamoozShop.Infrastructures.EF
{
    public class NikamoozStoreContext : DbContext
    {
        

        public NikamoozStoreContext(DbContextOptions option):base(option)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<CourseTeacher>().HasKey(c => new { c.CourseId, c.TeacherId });
            base.OnModelCreating(modelBuilder);

        }
    }
}