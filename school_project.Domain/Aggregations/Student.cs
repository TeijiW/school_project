using System;

namespace school_project.Domain.Aggregations
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public SchoolClass SchoolClass { get; set; }
        public int SchoolClassId { get; set; }
    }
}