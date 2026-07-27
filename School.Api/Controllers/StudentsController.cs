using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        [Route("GetAllStudents")]
        public IEnumerable<Student> Get()
        {
            //return new string[] { "value1", "value2" };
            return _db.Students.ToArray();
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
