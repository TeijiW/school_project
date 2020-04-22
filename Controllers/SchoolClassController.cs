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

    [Route("api/school-class")]
    [ApiController]
    public class SchoolClassController : ControllerBase
    {
        private readonly UnitOfWork _context;
        public SchoolClassController(UnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SchoolClass>> Get()
        {
            return _context.SchoolClassRepo.Get().ToList();
        }

        [HttpGet("{Id}", Name = "GetSchoolClass")]
        public ActionResult<SchoolClass> GetById(int Id)
        {
            var schoolClass = _context.SchoolClassRepo.GetById(s => s.Id == Id);
            if (schoolClass == null) { return NotFound(); }
            return schoolClass;
        }

        [HttpGet("students")]
        public ActionResult<IEnumerable<SchoolClass>> GetWithStudents()
        {
            return _context.SchoolClassRepo.GetWithStudents().ToList();
        }

        [HttpPost]
        public ActionResult Post([FromBody] SchoolClass schoolClass)
        {
            _context.SchoolClassRepo.Add(schoolClass);
            _context.Commit();
            return new CreatedAtRouteResult("GetSchoolClass", schoolClass);
        }

        [HttpPut("{Id}")]
        public ActionResult Put(int Id, [FromBody] SchoolClass schoolClass)
        {
            if (Id != schoolClass.Id) { return BadRequest(); }
            _context.SchoolClassRepo.Update(schoolClass);
            _context.Commit();
            return Ok();
        }

        [HttpDelete("{Id}")]
        public ActionResult<SchoolClass> Delete(int Id)
        {
            var schoolClass = _context.SchoolClassRepo.GetById(sc => sc.Id == Id);
            if (schoolClass == null) { return NotFound(); }
            _context.SchoolClassRepo.Delete(schoolClass);
            _context.Commit();
            return schoolClass;
        }

    }
}