using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheRestaurant.Domain.Entities;

namespace TheRestaurant.Test
{
    [TestClass]
    public class VoteTest
    {
        [TestMethod]
        public void CreateVoteAndSucceed()
        {
            // arrange
            var restaurant = new Restaurant(2);
            var professional = new Professional(1);

            // act
            var vote = new Vote(restaurant, professional);

            // assert
            Assert.AreEqual(professional.Id, vote.Professional.Id);
            Assert.AreEqual(restaurant.Id, vote.Restaurant.Id);
        }
    }
}
