using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Repositories
{
    public class DishRepository(RestaurantDbContext _dbContext) : IDishRepository
    {
        public async Task<int> CreateAsync(Dish dish)
        {
            await _dbContext.Dishes.AddAsync(dish);
            await _dbContext.SaveChangesAsync();
            return dish.Id;
        }

        public async Task DeleteAsync(IEnumerable<Dish> dishes)
        {
            _dbContext.Dishes.RemoveRange(dishes);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Dish>> GetAllAsync(int restaurantId)
        {
            var dishes = await _dbContext.Dishes.Where(d => d.RestaurantId == restaurantId).ToListAsync();
            return dishes;
        }

        public async Task<Dish?> GetByIdAsync(int restaurantId, int dishId)
        {
            return await _dbContext.Dishes.FirstOrDefaultAsync(d => d.RestaurantId == restaurantId && d.Id == dishId);
        }

        public async Task SaceChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
