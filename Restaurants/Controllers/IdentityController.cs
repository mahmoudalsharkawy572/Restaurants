using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Users.Commands.AssignUserRole;
using Restaurants.Application.Users.Commands.UnassignUserRole;
using Restaurants.Application.Users.Commands.UpdateUserDetailsCommand;
using Restaurants.Domain.Constants;

namespace Restaurants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(IMediator _mediator) : ControllerBase
    {
        [HttpPatch("update-user-details")]
        [Authorize]
        public async Task<ActionResult> UpdateUserDetails(UpdateUserDetailsCommand updateUserDetailsCommand)
        {
            await _mediator.Send(updateUserDetailsCommand);
            return NoContent();
        }

        [HttpPost("assign-user-role")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> AssignUserRole(AssignUserRoleCommand assignUserRoleCommand)
        {
            await _mediator.Send(assignUserRoleCommand);
            return NoContent();
        }

        [HttpPost("unassign-user-role")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> UnassignUserRole(UnassignUserRoleCommand unassignUserRoleCommand)
        {
            await _mediator.Send(unassignUserRoleCommand);
            return NoContent();
        }
    }
}
