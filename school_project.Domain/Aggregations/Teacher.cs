using System;
using System.Collections.Generic;

namespace school_project.Domain.Aggregations
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<ClassTeacher> ClassTeachers { get; set; }
    }
}