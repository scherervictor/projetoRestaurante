using System;

namespace TheRestaurant.Domain.Entities
{
    public class Vote : EntityBase
    {
        public Restaurant Restaurant { get; private set; }

        public Professional Professional { get; private set; }

        public DateTime TimeStamp { get; private set; }

        public Vote(Restaurant restaurant, Professional professional) : base(0)
        {
            Restaurant = restaurant;
            Professional = professional;
        }

        public Vote(long id) : base(id)
        { }
    }
}
