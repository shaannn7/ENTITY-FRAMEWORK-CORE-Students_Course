using EFPROJECT.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFPROJECT.Data
{
    public class DbContextClass:DbContext
    {
        private readonly IConfiguration _configuration;
        public string CString;
        public DbContextClass(IConfiguration configuration)
        {
            _configuration = configuration;
            CString = _configuration["ConnectionStrings:DefaultConnection"];
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CString);
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>()
                .HasOne(i => i.Course)
                .WithMany(i => i.Student_D)
                .HasForeignKey(i => i.CourseID);
            base.OnModelCreating(modelBuilder);
        }
    }
}
