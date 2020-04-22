using System.Collections.Generic;

namespace school_project.Domain.Aggregations
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<ClassTeacher> ClassTeachers { get; set; }
    }
}