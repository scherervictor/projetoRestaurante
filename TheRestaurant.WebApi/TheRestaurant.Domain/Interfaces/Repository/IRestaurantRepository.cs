using System.Collections.Generic;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities;

namespace TheRestaurant.Domain.Interfaces.Repository
{
    public interface IRestaurantRepository
    {
        Task VoteRestaurant(Vote vote);

        IEnumerable<Restaurant> GetWinnterRestaurant();

        void LogWinnerRestaurant(Restaurant restaurant);

        Winner GetLogWinner(long restaurantId);

        bool AlreadyVoted(Vote vote);

        bool RestaurantExists(Restaurant restaurant);
    }
}
