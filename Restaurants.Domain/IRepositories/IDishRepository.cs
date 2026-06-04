using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.IRepositories
{
    public interface IDishRepository
    {
        public Task<IEnumerable<Dish>> GetAllAsync(int restaurantId);
        public Task<Dish?> GetByIdAsync(int restaurantId, int dishId);
        public Task<int> CreateAsync(Dish dish);
        public Task DeleteAsync(IEnumerable<Dish> dishes);
        public Task SaceChanges();
    }
}
