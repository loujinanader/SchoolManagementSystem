using Microsoft.AspNetCore.Mvc;
using School.Api.Models.Student;
using School.Api.Services;
using School.Api.DTO.Student;

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
            var result = _service.GetAllStudents().Select(s => new StudentDto
            {
                StudentID = s.StudentID,
                StudentName = s.StudentName,
                Age = s.Age,
                ClassName = s.ClassRoom?.ClassName ?? ""
            });
            return Ok(result);
        }
     
        //(Read)
        // GET api/<StudentsController>/5
        [HttpGet("{id}")]

        public IActionResult GetStudentById(int id )
        {
            var student = _service.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            var dto = new StudentDto
            {
                StudentID = student.StudentID,
                StudentName = student.StudentName,
                Age = student.Age,
                ClassName = student.ClassRoom?.ClassName ?? ""
            };

            return Ok(dto);
        }




        //create
        // POST api/<StudentsController>
        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDto dto)
        {
           // if (!ModelState.IsValid) return BadRequest(ModelState);
            var student = new Student
            {
                StudentName = dto.StudentName,
                Age = dto.Age,
                CID = dto.CID
            };

            var createdStudent = _service.CreateStudent(student);

            return Ok(createdStudent);
        }





        // PUT api/<StudentsController>/5

        [HttpPatch("{id}")]
        public IActionResult UpdateStudent(int id, UpdateStudentDto dto)
        {
            var student = new Student
            {
                StudentName = dto.StudentName,
                Age = dto.Age,
                CID = dto.CID
            };

            var updatedStudent = _service.UpdateStudent(id, student);

            if (updatedStudent == null)
                return NotFound();

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
