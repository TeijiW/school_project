using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using school_project.Domain.Aggregations;
using school_project.Infra.Context;

namespace school_project.Infra.Repository
{
    public class SchoolClassRepository : Repository<SchoolClass>
    {
        public SchoolClassRepository(DatabaseContext context) : base(context) { }

        public bool CheckSchoolClass(int schoolClassId)
        {
            return Context.SchoolClasses.Any(sc => sc.Id == schoolClassId);
        }

        public IEnumerable<SchoolClass> GetWithStudents()
        {
            return Get().Include(sc => sc.Students);
        }
    }
}