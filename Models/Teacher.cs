using System;

namespace school_backend.Models {
    public class Teacher {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public DateTime Birthday { get; set; }
        public SchoolClass SchoolClass { get; set; }
        public int SchoolClassId { get; set; }
    }
}