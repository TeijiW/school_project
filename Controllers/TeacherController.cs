using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_backend.Context;
using school_backend.Models;
using school_backend.Repository;

namespace school_backend.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly UnitOfWork _context;
        public TeacherController(UnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> Get()
        {
            return _context.TeacherRepo.Get().ToList();
        }

        [HttpGet("{Id}", Name = "GetTeacher")]
        public ActionResult<Teacher> GetById(int Id)
        {
            var teacher = _context.TeacherRepo.GetById(t => t.Id == Id);
            if (teacher == null) { return NotFound(); }
            return teacher;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Teacher teacher)
        {

            var schoolClass = _context.SchoolClassRepo.CheckSchoolClass(teacher.SchoolClassId);
            if (!schoolClass) { return BadRequest("Invalid Class"); }
            _context.TeacherRepo.Add(teacher);
            _context.Commit();
            return new CreatedAtRouteResult("GetTeacher", new { id = teacher.Id }, teacher);
        }

        [HttpPut("{Id}")]
        public ActionResult Put(int Id, [FromBody] Teacher teacher)
        {
            if (Id != teacher.Id) { return BadRequest(); }
            _context.TeacherRepo.Update(teacher);
            _context.Commit();
            return Ok();
        }

        [HttpDelete("{Id}")]
        public ActionResult<Teacher> Delete(int Id)
        {
            var teacher = _context.TeacherRepo.GetById(t => t.Id == Id);
            if (teacher == null) { return NotFound(); }
            _context.TeacherRepo.Delete(teacher);
            _context.Commit();
            return teacher;
        }

    }
}