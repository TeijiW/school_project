using school_project.Domain.Aggregations;
using school_project.Infra.Context;

namespace school_project.Infra.Repository
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(DatabaseContext context) : base(context) { }
    }
}