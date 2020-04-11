using System.Collections.Generic;
using musics_api.Repository;
using Microsoft.EntityFrameworkCore;
using school_backend.Context;
using school_backend.Models;

namespace school_backend.Repositories {
    public class SchoolClassRepo : Repository<SchoolClass> {

        public SchoolClassRepo (DatabaseContext context) : base (context) { }

        public IEnumerable<object> GetWithStudents () {
            return Get ().Include (sc => sc.Students);
        }

        // Change "object" to "SchoolCLass" if return is "SchoolClass" and not "anonymous object"
        // public async Task<ActionResult<IEnumerable<object>>> GetWithStudents () {
        //     return await _context.SchoolClasses.Include (sc => sc.Students).ToListAsync ();
        // return await _context.SchoolClasses.Select
        // (sc => new
        // {
        //     ClassName = sc.Name,
        //     StudentName = sc.Students.Select(s => s.Name).ToArray()
        // }).ToListAsync();
        // }
    }
}