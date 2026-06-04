using AutoMapper;
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

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandHandler(IDishRepository _dishRepository, IRestaurantsRepository _restaurantsRepository
                                        , IMapper _mapper,ILogger<CreateDishCommand> _logger
                                        , IRestaurantAuthorizationService _restaurantAuthorizationService) : IRequestHandler<CreateDishCommand, int>
    {
        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating a new dish with @{DishRequest}", request);
            var restaurant = await _restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null)
                throw new NotFoundException(nameof(Restaurant),request.RestaurantId.ToString());
            if (_restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Update) == false)
                throw new UnauthorizedAccessException("You are not authorized to create this dish");
            var dish = _mapper.Map<Dish>(request);
            return await _dishRepository.CreateAsync(dish);
        }
    }
}
