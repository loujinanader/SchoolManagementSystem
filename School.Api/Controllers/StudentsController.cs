using Microsoft.AspNetCore.Mvc;
using School.Api.DTO.Request;
using School.Api.DTO.Response;
using School.Api.Services.StudentServices;
using Microsoft.AspNetCore.Authorization;
namespace School.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentsController(IStudentService service) =>  _service = service;
        // GET api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
        {
            var students = await _service.GetAllStudentsAsync();
            return Ok(students);
        }
        // GET api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(int id)
        {
            var student = await _service.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();
                return Ok(student);
        }

        // POST api/Students
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(CreateStudentRequest dto)
        {
            var created = await _service.CreateStudentAsync(dto);
            return CreatedAtAction(nameof(GetStudentById), new { id = created.StudentID }, created);
        }

        // PATCH api/Students/5
        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}")]
        public async Task<ActionResult<StudentDto>> UpdateStudent(int id, UpdateStudentDto dto)
        {
            var updated = await _service.UpdateStudentAsync(id, dto);
            if (updated == null)
                return NotFound();
                return Ok(updated);
        }

        // DELETE api/Students/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _service.DeleteStudentAsync(id);
            if (!deleted)
                return NotFound();
                return NoContent();
        }
    }
}
