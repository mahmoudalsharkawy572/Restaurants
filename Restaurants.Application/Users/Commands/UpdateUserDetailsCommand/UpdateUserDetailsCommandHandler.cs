using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;


namespace Restaurants.Application.Users.Commands.UpdateUserDetailsCommand
{
    public class UpdateUserDetailsCommandHandler(ILogger<UpdateUserDetailsCommand> _logger,
        IUserContext _userContext,IUserStore<User> _userStore) : IRequestHandler<UpdateUserDetailsCommand>
    {
        public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser();
            _logger.LogInformation("Updating details for user: {UserId} with details: {@Request}", user!.Id,request);

            var dbUser = await _userStore.FindByIdAsync(user.Id, cancellationToken);
            if (dbUser == null)
                throw new NotFoundException(nameof(User), user!.Id);

            dbUser.Nationality = request.Nationality;
            dbUser.DateOfBirth = request.DateOfBirth;

            await _userStore.UpdateAsync(dbUser, cancellationToken);
        }
    }
}
