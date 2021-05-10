namespace TheRestaurant.Domain.Entities
{
    public class Professional : EntityBase
    {
        public string Nome { get; private set; }

        public Professional(long id) : base(id)
        { }

        public Professional(long id, string nome) : base(id)
        {
            Nome = nome;
        }
    }
}
