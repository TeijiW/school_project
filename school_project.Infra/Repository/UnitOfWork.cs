using school_project.Infra.Context;

namespace school_project.Infra.Repository
{
    public class UnitOfWork
    {
        private StudentRepository _studentRepo;
        private SchoolClassRepository _schoolClassRepo;
        private TeacherRepository _teacherRepo;
        private ClassTeacherRepository _classTeacherRepo;
        public DatabaseContext Context;

        public UnitOfWork(DatabaseContext context)
        {
            Context = context;
        }

        public StudentRepository StudentRepo
        {
            get { return _studentRepo = _studentRepo ?? new StudentRepository(Context); }
        }

        public SchoolClassRepository SchoolClassRepo
        {
            get { return _schoolClassRepo = _schoolClassRepo ?? new SchoolClassRepository(Context); }
        }

        public TeacherRepository TeacherRepo
        {
            get { return _teacherRepo = _teacherRepo ?? new TeacherRepository(Context); }
        }

        public ClassTeacherRepository ClassTeacherRepo
        {
            get { return _classTeacherRepo = _classTeacherRepo ?? new ClassTeacherRepository(Context); }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

    }
}