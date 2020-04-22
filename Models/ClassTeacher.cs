namespace school_backend.Models
{
    public class ClassTeacher
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int SchoolClassId { get; set; }
        public SchoolClass SchoolClass { get; set; }
    }
}