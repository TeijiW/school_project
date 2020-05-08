namespace school_project.Domain.Aggregations
{
    public class ClassTeacher
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int SchoolClassId { get; set; }
        public SchoolClass SchoolClass { get; set; }
    }
}