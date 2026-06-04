using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<UpdateRestaurantCommand,Restaurant>();

            CreateMap<CreateRestaurantCommand, Restaurant>()
           .ForMember(d => d.Address, opt => opt.MapFrom(
               src => new Address
               {
                   City = src.City,
                   PostalCode = src.PostalCode,
                   Street = src.Street
               }));

            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(dist => dist.Street , src=>src.MapFrom(o=>o.Address.Street))
                .ForMember(dist => dist.City , src=>src.MapFrom(o=>o.Address.City))
                .ForMember(dist => dist.PostalCode , src=>src.MapFrom(o=>o.Address.PostalCode))
                .ForMember(dist => dist.Dishes , src=>src.MapFrom(o=>o.Dishes));
        }
    }
}
