using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant
{
    public class GetDishByIdForRestaurantQueryHandler(IDishRepository _dishRepository, IRestaurantsRepository _restaurantsRepository
                                        , IMapper _mapper, ILogger<GetDishByIdForRestaurantQuery> _logger) : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null)
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            var dish = await _dishRepository.GetByIdAsync(request.RestaurantId,request.DishId);
            if(dish==null)
                throw new NotFoundException(nameof(Dish), request.DishId.ToString());
            var dishDto = _mapper.Map<DishDto>(dish);
            return dishDto;

        }
    }
}
