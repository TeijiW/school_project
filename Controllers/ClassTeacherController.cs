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
    public class ClassTeacherController : ControllerBase
    {
        private readonly UnitOfWork _context;
        public ClassTeacherController(UnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClassTeacher>> Get()
        {
            return _context.ClassTeacherRepo.Get().ToList();
        }

        //  [HttpGet("{classId}, {teacherId}", Name = "GetClassTeacher")]
        // public ActionResult<Student> GetById(int classId, int teacherId)
        // {
        //     var classTeacher = _context.ClassTeacherRepo.GetById()
        //     var student = _context.StudentRepo.GetById(s => s.Id == Id);
        //     if (student == null) { return NotFound(); }
        //     return student;
        // }

        [HttpPost]
        public ActionResult Post([FromBody] ClassTeacher classTeacher)
        {
            var schoolClass = _context.SchoolClassRepo.CheckSchoolClass(classTeacher.SchoolClassId);
            var teacher = _context.TeacherRepo.CheckTeacher(classTeacher.TeacherId);
            if (!schoolClass || !teacher) { return BadRequest("Invalid Class Or Teacher"); }
            _context.ClassTeacherRepo.Add(classTeacher);
            _context.Commit();
            // return new CreatedResult(new { schoolClassId = classTeacher.SchoolClassId, teacherId = classTeacher.TeacherId });
            // return new CreatedAtRouteResult("GetStudent", new { id = classTeacher.Id }, student);
            return Ok();
        }
    }
}