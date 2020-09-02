using System.Threading.Tasks;
using API2.Application.Courses.Commands.CreateCourse;
using API2.Application.Courses.Commands.DeleteCourse;
using API2.Application.Courses.Commands.UpdateCourse;
using API2.Application.Courses.Queries.GetCourses;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API2.Controllers
{
    [Route("api/courses")]
    [EnableCors("AllowStudents")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCourse command)
        {
            var value = await _mediator.Send(command);
            return Ok(value);
        }
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateCourse command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromBody] DeleteCourse command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpGet("courses/{id:int}")]
        public async Task<ActionResult<CoursesVm>> GetFlashCards(int id)
        {
            var vm = await _mediator.Send(new GetCourses() { StudentId = id});
            return Ok(vm);
        }
    }
}
