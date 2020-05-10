using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using school_backend.Context;
using school_backend.Models;

namespace school_backend.Repository
{
    public class SchoolClassRepository : Repository<SchoolClass>
    {
        public SchoolClassRepository(DatabaseContext context) : base(context) { }

        public bool CheckSchoolClass(int schoolClassId)
        {
            return _context.SchoolClasses.Any(sc => sc.Id == schoolClassId);
        }

        public void AddTeacherToClass(SchoolClass schoolClass, Teacher teacher)
        {
            var classTeacher = new ClassTeacher();
            classTeacher.SchoolClassId = schoolClass.Id;
            classTeacher.TeacherId = teacher.Id;
            _context.ClassTeachers.Add(classTeacher);
        }

        public IEnumerable<SchoolClass> GetTeachersByClass(int classId)
        {
            return Get()
            .Where(sc => sc.Id == classId)
            .Include(sc => sc.ClassTeachers)
            .ThenInclude(ct => ct.Teacher);
        }

        public IEnumerable<SchoolClass> GetWithStudents()
        {
            return Get().Include(sc => sc.Students);
        }
    }
}