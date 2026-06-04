using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Commands.DeleteDishes
{
    public class DeleteDishesForRestaurantCommandHandler(IRestaurantsRepository _restaurantsRepository,IDishRepository _dishRepository,
                                                         ILogger<DeleteDishesForRestaurantCommand> _logger,
                                                         IRestaurantAuthorizationService _restaurantAuthorizationService) 
                                                        : IRequestHandler<DeleteDishesForRestaurantCommand>
    {
        public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogWarning("Removing all dishes from restaurant: {RestaurantId}", request.RestaurantId);
            var restaurant = await _restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if(restaurant == null)
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            if (_restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Delete) == false)
                throw new UnauthorizedAccessException("You are not authorized to delete this dish");
            await _dishRepository.DeleteAsync(restaurant.Dishes);

        }
    }
}
