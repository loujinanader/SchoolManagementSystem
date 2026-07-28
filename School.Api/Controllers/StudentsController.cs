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
        private readonly IStudentRepository _repository;


        public StudentsController(IStudentRepository repository)
        {
          _repository = repository;
        }


        // GET: api/<StudentsController>
        //(Read)
        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult Get()
        {
            var students = _repository.GetAllStudents();

            return Ok(students);
        }



        //(Read)
        // GET api/<StudentsController>/5
        [HttpGet("{id}")]

        public IActionResult GetStudentById(int id)
        {
            var student = _repository.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }




        //create
        // POST api/<StudentsController>
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateStudent(Student student)
        {
            _repository.CreateStudent(student);
            return Ok(student);
        }






        // PUT api/<StudentsController>/5

        [HttpPatch("{id}")]
        public IActionResult UpdateStudent(int id, Student obj)
        {
            var updatedStudent = _repository.UpdateStudent(id, obj);

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
            var student = _repository.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            _repository.DeleteStudent(id);

            return Ok(student);
        }
    }
}