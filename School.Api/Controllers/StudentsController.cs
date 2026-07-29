using Microsoft.AspNetCore.Mvc;
using School.Api.Models.Student;
using School.Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;


        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        // GET: api/<StudentsController>
        //(Read)
        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult Get()
        {
            var students = _service.GetAllStudents();

            return Ok(students);
        }



        //(Read)
        // GET api/<StudentsController>/5
        [HttpGet("{id}")]

        public IActionResult GetStudentById(int id)
        {
            var student = _service.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }




        //create
        // POST api/<StudentsController>
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            var createdStudent = _service.CreateStudent(student);

            return Ok(createdStudent);
        }





        // PUT api/<StudentsController>/5

        [HttpPatch("{id}")]
        public IActionResult UpdateStudent(int id, Student obj)
        {
            var updatedStudent = _service.UpdateStudent(id, obj);

            if (updatedStudent == null)
            {
                return NotFound();
            }

            return Ok(updatedStudent);
        }

        // DELETE api/<StudentsController>/5 
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _service.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            _service.DeleteStudent(id);

            return Ok(student);
        }
    }
}