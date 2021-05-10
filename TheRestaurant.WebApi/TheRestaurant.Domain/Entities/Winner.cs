using System;

namespace TheRestaurant.Domain.Entities
{
    public class Winner : EntityBase
    {
        public Restaurant Restaurant { get; private set; }

        public DateTime Timestamp { get; private set; }

        public Winner(long id, Restaurant restaurant) : base(id)
        {
            Restaurant = restaurant;
        }
        
        protected Winner()
        { }

        public void SetRestaurant(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }
    }
}
