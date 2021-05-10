using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Application.Dtos;
using TheRestaurant.Application.Interfaces.Services;
using TheRestaurant.Domain.Bases;
using TheRestaurant.WebApi.Api;

namespace TheRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerApi
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        [Route("todayLunch")]
        public IActionResult Get() =>
             Response(_restaurantService.GetTodayLunch());

        [HttpPost]
        [Route("vote")]
        public IActionResult Post([FromBody] VoteDto voteDto) =>
            Response(_restaurantService.Vote(voteDto));
    }
}
