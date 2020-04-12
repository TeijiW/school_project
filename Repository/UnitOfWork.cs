using school_backend.Context;

namespace school_backend.Repository
{
    public class UnitOfWork
    {
        private StudentRepository _studentRepo;
        private SchoolClassRepository _schoolClassRepo;
        private TeacherRepository _teacherRepo;
        public DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public StudentRepository StudentRepo
        {
            get { return _studentRepo = _studentRepo ?? new StudentRepository(_context); }
        }

        public SchoolClassRepository SchoolClassRepo
        {
            get { return _schoolClassRepo = _schoolClassRepo ?? new SchoolClassRepository(_context); }
        }

        public TeacherRepository TeacherRepo
        {
            get { return _teacherRepo = _teacherRepo ?? new TeacherRepository(_context); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}