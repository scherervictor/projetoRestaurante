using TheRestaurant.Domain.Entities;

namespace TheRestaurant.Domain.Interfaces.Repository
{
    public interface IProfessionalRepository
    {
        bool ProfessionalExists(Professional professional);
    }
}
