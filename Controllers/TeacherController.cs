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
    public class TeacherController : ControllerBase {
        private readonly DatabaseContext _context;
        public TeacherController (DatabaseContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> Get () {
            return await _context.Teachers.AsNoTracking ().ToListAsync ();
        }

        [HttpGet ("{Id}", Name = "GetTeacher")]
        public async Task<ActionResult<Teacher>> GetById (int Id) {
            var teacher = await _context.Teachers.AsNoTracking ().FirstOrDefaultAsync (s => s.Id == Id);
            if (teacher == null) { return NotFound (); }
            return teacher;
        }

        [HttpPost]
        public ActionResult Post ([FromBody] Teacher teacher) {

            var schoolClass = _context.SchoolClasses.Any (sc => sc.Id == teacher.SchoolClassId);
            if (!schoolClass) { return BadRequest ("Invalid Class"); }
            _context.Teachers.Add (teacher);
            _context.SaveChanges ();
            return new CreatedAtRouteResult ("GetTeacher", new { id = teacher.Id }, teacher);
        }

        [HttpPut ("{Id}")]
        public ActionResult Put (int Id, [FromBody] Teacher teacher) {
            if (Id != teacher.Id) { return BadRequest (); }
            _context.Entry (teacher).State = EntityState.Modified;
            _context.SaveChanges ();
            return Ok ();
        }

        [HttpDelete ("{Id}")]
        public ActionResult<Teacher> Delete (int Id) {
            var teacher = _context.Teachers.FirstOrDefault (t => t.Id == Id);
            if (teacher == null) { return NotFound (); }
            _context.Teachers.Remove (teacher);
            _context.SaveChanges ();
            return teacher;
        }

    }
}