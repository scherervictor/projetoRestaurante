using TheRestaurant.Application.Dtos;
using TheRestaurant.Domain.Bases;

namespace TheRestaurant.Application.Interfaces.Services
{
    public interface IRestaurantService
    {
        BaseResult Vote(VoteDto voteDto);

        BaseResult<RestaurantDto> GetTodayLunch();
    }
}
