using school_backend.Context;
using school_backend.Models;

namespace school_backend.Repository
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(DatabaseContext context) : base(context) { }
    }
}