using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TheRestaurant.Domain.Bases;

namespace TheRestaurant.WebApi.Api
{
    public class ControllerApi : ControllerBase
    {
        protected new IActionResult Response<T>(BaseResult<T> result)
        {
            if (result.Data == null && !result.Messages.Any())
                return NotFound(result);

            if (result.Data == null && result.Messages.Any())
                return BadRequest(result);

            return Ok(result);
        }

        protected new IActionResult Response(BaseResult result)
        {
            if (!result.Valid)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
