using System.Threading.Tasks;
using API1.Models;
using API1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API1.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _studentService.GetAllStudents());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await _studentService.GetStudentById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student request)
        {
            var result = await _studentService.CreateStudentAsync(request);

            if (result == 0)
                return BadRequest(new { Error = "Sorry, there was a problem adding the student. Please try again" });

            return Ok(new { StudentId = result });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Student request)
        {
            var result = await _studentService.UpdateStudent(request); ;

            if (result)
                return NoContent();

            return BadRequest(new { Error = "Sorry, there was a problem updating the student. Please try again" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _studentService.DeleteStudent(id); ;

            if (result)
                return NoContent();

            return BadRequest(new { Error = "Sorry, there was a problem deleting the student. Please try again" });
        }

        [HttpGet("courses/{id}")]
       
        public async Task<IActionResult> GetCourses([FromRoute] int id)
        {
            return Ok(await _studentService.CoursesByStudent(id));
        }
    }
}
