// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using school_backend.Context.Maps;
using school_backend.Models;

namespace school_backend.Context {
    public class DatabaseContext : DbContext {
        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base (options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating (ModelBuilder builder) {
            builder.ApplyConfiguration (new SchoolClassMap ());
            builder.ApplyConfiguration (new TeacherMap ());
            builder.ApplyConfiguration (new StudentMap ());
            base.OnModelCreating (builder);
        }

    }
}