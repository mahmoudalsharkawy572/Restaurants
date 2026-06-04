using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
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

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommand> _logger
                                               , IMapper _mapper, IRestaurantsRepository _restaurantsRepository
                                               , IRestaurantAuthorizationService _restaurantAuthorizationService) : IRequestHandler<UpdateRestaurantCommand>
    {
        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Update Restaurant with id {Id} By {@Restaurant}", request.Id, request);
            var restaurant = await _restaurantsRepository.GetByIdAsync(request.Id);
            if (restaurant == null)
                throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
            if (_restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Update) == false)
                throw new UnauthorizedAccessException("You are not authorized to update this restaurant");
            _mapper.Map(request, restaurant);
            await _restaurantsRepository.SaceChanges();

        }
    }
}
