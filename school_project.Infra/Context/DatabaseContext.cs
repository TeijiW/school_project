using Microsoft.EntityFrameworkCore;
using school_project.Domain.Aggregations;

namespace school_project.Infra.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ClassTeacher> ClassTeachers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //// TODO: [frvs] fix this (why doesnt works?)
            
            //builder.ApplyConfiguration(new SchoolClassMap());
            //builder.ApplyConfiguration(new TeacherMap());
            //builder.ApplyConfiguration(new StudentMap());
            //builder.ApplyConfiguration(new ClassTeacherMap());
            //base.OnModelCreating(builder);
        }

    }
}