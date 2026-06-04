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

namespace Restaurants.Application.Users.Commands.AssignUserRole
{
    public class AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommand> _logger,
                                              UserManager<User> _userManager,
                                              RoleManager<IdentityRole> _roleManager) : IRequestHandler<AssignUserRoleCommand>
    {
        public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Assigning role {Role} to user {UserEmail}", request.UserRole, request.UserEmail);
            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
                throw new NotFoundException(nameof(User), request.UserEmail);

            var role = await _roleManager.FindByNameAsync(request.UserRole);
            if (role == null)
                throw new NotFoundException(nameof(IdentityRole), request.UserRole);

            var res =  await _userManager.AddToRoleAsync(user, role.Name!);
            if(res.Succeeded)
            {
                _logger.LogInformation("Role {Role} assigned to user {UserEmail}", request.UserRole, request.UserEmail);
            }
        }
    }
}
