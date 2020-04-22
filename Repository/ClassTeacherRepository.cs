using school_backend.Context;
using school_backend.Models;

namespace school_backend.Repository
{
    public class ClassTeacherRepository : Repository<ClassTeacher>
    {
        public ClassTeacherRepository(DatabaseContext context) : base(context) { }
    }
}