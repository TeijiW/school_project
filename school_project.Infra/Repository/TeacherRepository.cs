using System.Linq;
using school_project.Domain.Aggregations;
using school_project.Infra.Context;

namespace school_project.Infra.Repository
{
    public class TeacherRepository : Repository<Teacher>
    {
        public TeacherRepository(DatabaseContext context) : base(context) { }

        public bool CheckTeacher(int teacherId)
        {
            return Context.Teachers.Any(t => t.Id == teacherId);
        }
    }
}