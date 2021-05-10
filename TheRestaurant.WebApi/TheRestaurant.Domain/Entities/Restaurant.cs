namespace TheRestaurant.Domain.Entities
{
    public class Restaurant : EntityBase
    {
        public string Nome { get; private set; }

        public Restaurant(long id) : base(id)
        { }

        public Restaurant(string nome) : base(0)
        {
            Nome = nome;
        }

        protected Restaurant()
        { }
    }
}
