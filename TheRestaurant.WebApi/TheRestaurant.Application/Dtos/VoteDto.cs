using System;
using System.Collections.Generic;
using System.Text;

namespace TheRestaurant.Application.Dtos
{
    public class VoteDto
    {
        public long? RestaurantId { get; set; }

        public long? ProfessionalId { get; set; }
    }
}
