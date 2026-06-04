using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Domain.Constants;
using Restaurants.Infrastructure.Authorization;

namespace Restaurants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAllRestaurants([FromQuery]GetAllRestaurantsQuery getAllRestaurantsQuery)
        {
            var restaurants = await _mediator.Send(getAllRestaurantsQuery);
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.HasNationality)]
        public async Task<ActionResult<RestaurantDto>> GetRestaurantById([FromRoute] int id)
        {
            var restaurant = await _mediator.Send(new GetRestaurantByIdQuery(id));
            return Ok(restaurant);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Owner)]
        public async Task<ActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand createRestaurantCommand)
        {
            int id = await _mediator.Send(createRestaurantCommand);
            return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRestaurantById([FromRoute] int id)
        {
            await _mediator.Send(new DeleteRestaurantCommand(id));
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateRestaurant([FromRoute] int id, UpdateRestaurantCommand updateRestaurantQuery)
        {
            updateRestaurantQuery.Id = id;
            await _mediator.Send(updateRestaurantQuery);
            return NoContent();
        }
    }
}
