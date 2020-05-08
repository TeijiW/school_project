using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school_project.Domain.Aggregations;

namespace school_project.Infra.Context.Maps
{
    public class ClassTeacherMap : IEntityTypeConfiguration<ClassTeacher>
    {
        public void Configure(EntityTypeBuilder<ClassTeacher> builder)
        {
            builder.ToTable("ClassTeacher");
            builder.HasKey(ct => new { ct.SchoolClassId, ct.TeacherId });
        }

    }
}