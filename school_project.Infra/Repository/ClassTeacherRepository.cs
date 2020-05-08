using school_project.Domain.Aggregations;
using school_project.Infra.Context;

namespace school_project.Infra.Repository
{
    public class ClassTeacherRepository : Repository<ClassTeacher>
    {
        public ClassTeacherRepository(DatabaseContext context) : base(context) { }
    }
}