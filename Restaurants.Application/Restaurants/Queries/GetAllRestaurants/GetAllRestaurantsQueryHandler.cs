using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQuery> _logger
                                             , IMapper _mapper, IRestaurantsRepository _restaurantsRepository)
                                             : IRequestHandler<GetAllRestaurantsQuery, PagedResult<RestaurantDto>>
    {
        public async Task<PagedResult<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all restaurants from the repository.");
            var  (restaurants, totalCount) = await _restaurantsRepository.GetAllMatchingAsync(request.SearchPhrase, request.PageNumber, request.PageSize,request.SortBy,request.SortDirection);
            var restaurantsDto = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            var pagedResult = new PagedResult<RestaurantDto>(restaurantsDto,totalCount, request.PageNumber, request.PageSize);
           
            return pagedResult;
        }
    }
}
