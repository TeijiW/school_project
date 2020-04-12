using school_backend.Context;
using school_backend.Models;

namespace school_backend.Repository
{
    public class TeacherRepository : Repository<Teacher>
    {
        public TeacherRepository(DatabaseContext context) : base(context) { }
    }
}