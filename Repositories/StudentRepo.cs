using musics_api.Repository;
using school_backend.Context;
using school_backend.Models;

namespace school_backend.Repositories {
    public class StudentRepo : Repository<Student> {

        public StudentRepo (DatabaseContext context) : base (context) { }
        // private readonly DatabaseContext _context;
        // public StudentRepo (DatabaseContext context) {
        //     _context = context;
        // }
    }
}