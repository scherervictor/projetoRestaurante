using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheRestaurant.Domain.Entities;

namespace TheRestaurant.Test
{
    [TestClass]
    public class RestaurantTest
    {
        [TestMethod]
        public void CreateRestaurantAndSucceed()
        {
            // arrange
            var restaurantName = "Victor";

            // act
            var restaurant = new Restaurant(restaurantName);

            // assert
            Assert.AreEqual(restaurantName, restaurant.Nome);
        }
    }
}
