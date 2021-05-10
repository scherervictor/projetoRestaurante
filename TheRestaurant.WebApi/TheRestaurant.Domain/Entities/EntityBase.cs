namespace TheRestaurant.Domain.Entities
{
    public abstract class EntityBase
    {
        public long Id { get; private set; }

        public EntityBase(long id)
        {
            Id = id;
        }

        public EntityBase()
        { }
    }
}
