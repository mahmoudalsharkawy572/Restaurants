using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Users;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> _logger
                                               ,IMapper _mapper 
                                               ,IUserContext _userContext 
                                               ,IRestaurantsRepository _restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            _logger.LogInformation("Creating a new restaurant {@Restaurant}",request);
            var restaurant = _mapper.Map<Restaurant>(request);
            restaurant.OwnerId = currentUser.Id;
            int id = await _restaurantsRepository.CreateAsync(restaurant);
            return id;
        }
    }
}
