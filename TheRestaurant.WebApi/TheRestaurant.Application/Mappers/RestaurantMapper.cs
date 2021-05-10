using TheRestaurant.Application.Dtos;
using TheRestaurant.Domain.Entities;

namespace TheRestaurant.Application.Mappers
{
    public static class RestaurantMapper
    {
        public static RestaurantDto MapDto(Restaurant restaurant) =>
            new RestaurantDto
            {
                Id = restaurant.Id,
                Nome = restaurant.Nome
            };
    }
}
