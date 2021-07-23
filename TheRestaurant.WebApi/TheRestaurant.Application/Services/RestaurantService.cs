using System;
using System.Linq;
using TheRestaurant.Application.Dtos;
using TheRestaurant.Application.Interfaces.Services;
using TheRestaurant.Application.Mappers;
using TheRestaurant.Domain.Bases;
using TheRestaurant.Domain.Entities;
using TheRestaurant.Domain.Interfaces.Repository;

namespace TheRestaurant.Application.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IProfessionalRepository _professionalRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository, IProfessionalRepository professionalRepository)
        {
            _restaurantRepository = restaurantRepository;
            _professionalRepository = professionalRepository;
        }

        public BaseResult<RestaurantDto> GetTodayLunch()
        {
            var result = new BaseResult<RestaurantDto>();

            var winnerRestaurants = _restaurantRepository.GetWinnterRestaurant();

            if (!winnerRestaurants.Any())
            {
                result.Messages.Add("Cant get winner restaurant");
                return result;
            }

            Restaurant winnerRestaurant = null;
            foreach (var restaurant in winnerRestaurants)
            {
                var winnerLog = _restaurantRepository.GetLogWinner(restaurant.Id);

                if (winnerLog ==  null || !DatesAreInTheSameWeek(winnerLog.Timestamp, DateTime.Now))
                {
                    winnerRestaurant = restaurant;
                    break;
                }                    
            }

            if (winnerRestaurant == null)
            {
                result.Messages.Add("Cant get winner restaurant");
                return result;
            }

            _restaurantRepository.LogWinnerRestaurant(winnerRestaurant);

            result.Data = RestaurantMapper.MapDto(winnerRestaurant);

            return result;
        }

        public BaseResult Vote(VoteDto voteDto)
        {
            var result = new BaseResult();

            if (voteDto.ProfessionalId == null || voteDto.RestaurantId == null)
            {
                result.Messages.Add("Professional Id or Restaurant Id was invalid");
                return result;
            }

            var professional = new Professional(voteDto.ProfessionalId.Value);
            if (!_professionalRepository.ProfessionalExists(professional))
            {
                result.Messages.Add("Professional not found");
                return result;
            }

            var restaurant = new Restaurant(voteDto.RestaurantId.Value);
            if (!_restaurantRepository.RestaurantExists(restaurant))
            {
                result.Messages.Add("Restaurant not found");
                return result;
            }

            var vote = new Vote(restaurant, professional);
            if (_restaurantRepository.AlreadyVoted(vote))
            {
                result.Messages.Add("You already voted for today, try again later.");
                return result;
            }

            var teste2 = "qualquercoisa";

            _restaurantRepository.VoteRestaurant(vote);

            return result;
        }

        private bool DatesAreInTheSameWeek(DateTime date1, DateTime date2)
        {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = date1.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date1));
            var d2 = date2.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date2));

            return d1 == d2;
        }
    }
}
