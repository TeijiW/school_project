using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using school_project.Domain.Aggregations;
using school_project.Infra.Repository;

namespace school_project.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly UnitOfWork _context;
        public StudentController(UnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return _context.StudentRepo.Get().ToList();
        }

        [HttpGet("{Id}", Name = "GetStudent")]
        public ActionResult<Student> GetById(int Id)
        {
            var student = _context.StudentRepo.GetById(s => s.Id == Id);
            if (student == null) { return NotFound(); }
            return student;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Student student)
        {
            var schoolClass = _context.SchoolClassRepo.CheckSchoolClass(student.SchoolClassId);
            if (!schoolClass) { return BadRequest("Invalid Class"); }
            _context.StudentRepo.Add(student);
            _context.Commit();
            return new CreatedAtRouteResult("GetStudent", new { id = student.Id }, student);
        }

        [HttpPut("{Id}")]
        public ActionResult Put(int Id, [FromBody] Student student)
        {
            if (Id != student.Id) { return BadRequest(); }
            _context.StudentRepo.Update(student);
            _context.Commit();
            return Ok();
        }

        [HttpDelete("{Id}")]
        public ActionResult<Student> Delete(int Id)
        {
            var student = _context.StudentRepo.GetById(s => s.Id == Id);
            if (student == null) { return NotFound(); }
            _context.StudentRepo.Delete(student);
            _context.Commit();
            return student;
        }

    }
}