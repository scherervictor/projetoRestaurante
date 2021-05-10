using System.Collections.Generic;
using System.Linq;
using TheRestaurant.Domain.Entities;
using TheRestaurant.Domain.Interfaces.Repository;

namespace TheRestaurant.Infra.Repositories
{
    public class MockProfessionalRepository : IProfessionalRepository
    {
        private readonly List<Professional> Professionals = new List<Professional> {
            new Professional(1, "João"),
            new Professional(2, "Victor"),
            new Professional(3, "Catherine"),
            new Professional(4, "Osvaldo"),
            new Professional(5, "Patrick"),
            new Professional(6, "Belloto"),
            new Professional(7, "Dioudi"),
            new Professional(8, "Molina"),
        };

        public bool ProfessionalExists(Professional professional)
        {
            return Professionals.Any(x => x.Id == professional.Id);
        }
    }
}
