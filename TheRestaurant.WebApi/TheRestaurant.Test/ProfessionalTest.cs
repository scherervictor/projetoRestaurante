using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheRestaurant.Domain.Entities;

namespace TheRestaurant.Test
{
    [TestClass]
    public class ProfessionalTest
    {
        [TestMethod]
        public void CreateProfessionalAndSucceed()
        {
            // arrange
            var professionalName = "Victor";
            var professionalId = 1;

            // act
            var professional = new Professional(professionalId, professionalName);

            // assert
            Assert.AreEqual(professionalName, professional.Nome);
            Assert.AreEqual(professionalId, professional.Id);
        }
    }
}
