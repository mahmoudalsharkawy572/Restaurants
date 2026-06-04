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

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommand> _logger
                                               , IMapper _mapper, IRestaurantsRepository _restaurantsRepository
                                               , IRestaurantAuthorizationService _restaurantAuthorizationService) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleteing Restaurant with id : {request.Id}", request.Id);
            var resturant = await _restaurantsRepository.GetByIdAsync(request.Id);
            if (resturant == null)
                throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

            if(_restaurantAuthorizationService.Authorize(resturant,ResourceOperation.Delete) == false)
                throw new UnauthorizedAccessException("You are not authorized to delete this restaurant");

            await _restaurantsRepository.DeleteAsync(resturant);

        }
    }
}
