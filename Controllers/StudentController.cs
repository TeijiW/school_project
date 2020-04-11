using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_backend.Context;
using school_backend.Models;

namespace school_backend.Controllers {
    [Route ("api/[Controller]")]
    [ApiController]
    public class StudentController : ControllerBase {
        private readonly DatabaseContext _context;
        public StudentController (DatabaseContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get () {
            return await _context.Students.AsNoTracking ().ToListAsync ();
        }

        [HttpGet ("{Id}", Name = "GetStudent")]
        public async Task<ActionResult<Student>> GetById (int Id) {
            var student = await _context.Students.AsNoTracking ().FirstOrDefaultAsync (s => s.Id == Id);
            if (student == null) { return NotFound (); }
            return student;
        }

        [HttpPost]
        public ActionResult Post ([FromBody] Student student) {
            var schoolClass = _context.SchoolClasses.Any (sc => sc.Id == student.SchoolClassId);
            if (!schoolClass) { return BadRequest ("Invalid Class"); }
            _context.Students.Add (student);
            _context.SaveChanges ();
            return new CreatedAtRouteResult ("GetStudent", new { id = student.Id }, student);
        }

        [HttpPut ("{Id}")]
        public ActionResult Put (int Id, [FromBody] Student student) {
            if (Id != student.Id) { return BadRequest (); }
            _context.Entry (student).State = EntityState.Modified;
            _context.SaveChanges ();
            return Ok ();
        }

        [HttpDelete ("{Id}")]
        public ActionResult<Student> Delete (int Id) {
            var student = _context.Students.FirstOrDefault (s => s.Id == Id);
            if (student == null) { return NotFound (); }
            _context.Students.Remove (student);
            _context.SaveChanges ();
            return student;
        }

    }
}