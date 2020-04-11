using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_backend.Context;
using school_backend.Models;

namespace school_backend.Controllers {
    // Route be api/schoolclass at this way
    // [Route("api/[Controller]")] 

    [Route ("api/school-class")]
    [ApiController]
    public class SchoolClassController : ControllerBase {
        private readonly DatabaseContext _context;
        public SchoolClassController (DatabaseContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolClass>>> Get () {
            return await _context.SchoolClasses.AsNoTracking ().ToListAsync ();
        }

        [HttpGet ("{Id}", Name = "GetSchoolClass")]
        public async Task<ActionResult<SchoolClass>> GetById (int Id) {
            var schoolClass = await _context.SchoolClasses.AsNoTracking ().FirstOrDefaultAsync (s => s.Id == Id);
            if (schoolClass == null) { return NotFound (); }
            return schoolClass;
        }

        [HttpGet ("students")]
        // Change "object" to "SchoolCLass" if return is "SchoolClass" and not "anonymous object"
        public async Task<ActionResult<IEnumerable<object>>> GetWithStudents () {
            return await _context.SchoolClasses.Include (sc => sc.Students).ToListAsync ();
            // return await _context.SchoolClasses.Select
            // (sc => new
            // {
            //     ClassName = sc.Name,
            //     StudentName = sc.Students.Select(s => s.Name).ToArray()
            // }).ToListAsync();
        }

        [HttpPost]
        public ActionResult Post ([FromBody] SchoolClass schoolClass) {
            _context.SchoolClasses.Add (schoolClass);
            _context.SaveChanges ();
            return new CreatedAtRouteResult ("GetSchoolClass", schoolClass);
        }

        [HttpPut ("{Id}")]
        public ActionResult Put (int Id, [FromBody] SchoolClass schoolClass) {
            if (Id != schoolClass.Id) { return BadRequest (); }
            _context.Entry (schoolClass).State = EntityState.Modified;
            _context.SaveChanges ();
            return Ok ();
        }

        [HttpDelete ("{Id}")]
        public ActionResult<SchoolClass> Delete (int Id) {
            var schoolClass = _context.SchoolClasses.FirstOrDefault (sc => sc.Id == Id);
            if (schoolClass == null) { return NotFound (); }
            _context.SchoolClasses.Remove (schoolClass);
            _context.SaveChanges ();
            return schoolClass;
        }

    }
}