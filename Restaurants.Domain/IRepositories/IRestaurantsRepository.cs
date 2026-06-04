using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.IRepositories
{
    public interface IRestaurantsRepository
    {
        public Task<IEnumerable<Restaurant>> GetAllAsync();
        public Task<(IEnumerable<Restaurant>, int)> GetAllMatchingAsync(string? searchPhrase,
          int pageSize,
          int pageNumber,
          string? sortBy,
          SortDirection sortDirection);
        public Task<Restaurant> GetByIdAsync(int id);
        public Task<int> CreateAsync(Restaurant restaurant);
        public Task DeleteAsync(Restaurant entity);
        public Task SaceChanges();

    }
}
