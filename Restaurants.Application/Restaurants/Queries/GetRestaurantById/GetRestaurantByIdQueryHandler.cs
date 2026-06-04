using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQuery> _logger
                                               , IMapper _mapper, IRestaurantsRepository _restaurantsRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
    {
        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching a restaurant by ID : {request.Id} from the repository.",request.Id);
            var restaurant = await _restaurantsRepository.GetByIdAsync(request.Id);
            if (restaurant == null)
                throw new NotFoundException(nameof(Restaurant),request.Id.ToString());
            var restaurantsDto = _mapper.Map<RestaurantDto>(restaurant);
            return restaurantsDto;
        }
    }
}
