using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Users.Commands.UnassignUserRole
{
    public class UnassignUserRoleCommandHandler(ILogger<UnassignUserRoleCommand> _logger,
                                                UserManager<User> _userManager,
                                                RoleManager<IdentityRole> _roleManager) : IRequestHandler<UnassignUserRoleCommand>
    {
        public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("UnassignUserRoleCommand for user {UserEmail} and role {RoleName}", request.UserEmail, request.RoleName);
            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null) 
                throw new NotFoundException(nameof(user),request.UserEmail);

            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if (role == null)
                throw new NotFoundException(nameof(IdentityRole), request.RoleName);

            await _userManager.RemoveFromRoleAsync(user, role.Name!);
        }
    }
}
