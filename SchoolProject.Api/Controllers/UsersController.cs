using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Features.Users.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : AppControllerBase
    {
        #region GetUserById
        [HttpGet(Router.UserRouting.GetUserDetails)]
        public async Task<IActionResult> GetUserById([FromRoute] Guid Id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery(Id));
            return NewResult(response);
        }

        #endregion

        #region PaginatedUsers
        [HttpGet(Router.UserRouting.Paginated)]
        public async Task<IActionResult> PaginatedUsers([FromQuery] GetUsersPaginationQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        #endregion

        #region CreateUser

        [HttpPost(Router.UserRouting.CreateUser)]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion

        #region EditUser

        [HttpPut(Router.UserRouting.EditUser)]
        public async Task<IActionResult> EditUser([FromBody] EditUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion

        #region ChangeUserPassword

        [HttpPut(Router.UserRouting.ChangePassword)]
        public async Task<IActionResult> EditUserPassword([FromForm] ChangeUserPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion

        #region DeleteUser
        [HttpDelete(Router.UserRouting.DeleteUser)]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid Id)
        {
            var response = await Mediator.Send(new DeleteUserCommand(Id));
            return NewResult(response);
        }
        #endregion
    }
}
