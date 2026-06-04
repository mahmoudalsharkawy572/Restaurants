using Microsoft.AspNetCore.Authorization;
using Restaurants.Application.Users;
using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Authorization.Requirements
{
    public class CreatedMultipleRestaurantsRequirementHandler(IRestaurantsRepository _restaurantsRepository
                                                              ,IUserContext _userContext) : AuthorizationHandler<CreatedMultipleRestaurantsRequirement>
    {
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, CreatedMultipleRestaurantsRequirement requirement)
        {
            var currentUser = _userContext.GetCurrentUser();

            var restaurants = await _restaurantsRepository.GetAllAsync();

            var userRestaurantsCreated = restaurants.Count(r => r.OwnerId == currentUser!.Id);

            if (userRestaurantsCreated >= requirement.MinimumRestaurantsCreated)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
