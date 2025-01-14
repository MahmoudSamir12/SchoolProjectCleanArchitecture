using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentController : AppControllerBase
    {

        [HttpGet(Router.StudentRouting.AllStudents)]
        public async Task<IActionResult> GetAllStudents()
        {
            var response = await Mediator.Send(new GetAllStudentsQuery());
            return Ok(response);
        }

        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> PaginatedStudents([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(Router.StudentRouting.GetStudentDetails)]
        public async Task<IActionResult> GetStudentById([FromRoute] Guid Id)
        {
            var response = await Mediator.Send(new GetStudentByIdQuery(Id));
            return NewResult(response);
        }

        [HttpPost(Router.StudentRouting.CreateStudent)]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Router.StudentRouting.UpdateStudent)]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.StudentRouting.DeleteStudent)]
        public async Task<IActionResult> DeleteStuent([FromRoute] Guid Id)
        {
            var response = await Mediator.Send(new DeleteStudentCommand(Id));
            return NewResult(response);
        }


    }
}
