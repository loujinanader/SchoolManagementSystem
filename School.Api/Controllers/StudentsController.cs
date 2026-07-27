using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Api.Data;
using School.Api.Models.Student;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolContext _db;

        public StudentsController( SchoolContext db )
        {
            _db = db;
        }
        // GET: api/<StudentsController>
        //(Read)
        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult Get()
        {
            var students = _db.Students
                .Include(s => s.ClassRoom)
                .Select(s => new
                {
                    s.StudentID,
                    s.StudentName,
                    s.Age,
                    s.CID,
                    ClassName = s.ClassRoom.ClassName
                })
                .ToList();

            return Ok(students);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentsController>
        [HttpPost]
        [Route("UpdateStudent")]
        public Student CreateNewStudent(Student obj)
        {
            _db.Students.Add(obj);
            _db.SaveChanges();
            return obj;
        }
        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public Student updateStudent(Student obj, int id)
        {
            var StudentData = _db.Students.FirstOrDefault(x => x.StudentID == obj.StudentID);
            StudentData.StudentName = obj.StudentName;
            StudentData.Age = obj.Age;
            StudentData.CID = obj.CID;
            StudentData.ClassRoom = obj.ClassRoom;
            StudentData.StudentID = obj.StudentID;
            _db.SaveChanges();
            return obj;
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
