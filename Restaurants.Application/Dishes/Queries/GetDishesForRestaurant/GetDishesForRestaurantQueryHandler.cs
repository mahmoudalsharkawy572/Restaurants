using AutoMapper;
using MediatR;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Queries.GetDishesForRestaurant
{
    internal class GetDishesForRestaurantQueryHandler(IDishRepository _dishRepository,IRestaurantsRepository _restaurantsRepository
                                                     ,IMapper _mapper) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>>
    {
        public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if(restaurant == null)
                throw new NotFoundException(nameof(Restaurant),request.RestaurantId.ToString());
            var dishes = await _dishRepository.GetAllAsync(request.RestaurantId);
            return  _mapper.Map<IEnumerable<DishDto>>(dishes);
        }
    }
}
