using Microsoft.AspNetCore.Mvc;
using School.Api.Data;

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
            
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //return new string[] { "value1", "value2" };
            return _db.Students.Select(s => s.StudentName).ToArray();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
