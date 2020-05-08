using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using school_project.Domain.Aggregations;
using school_project.Infra.Repository;

namespace school_project.Controllers
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