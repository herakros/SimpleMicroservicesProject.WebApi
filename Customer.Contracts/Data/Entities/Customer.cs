namespace CustomerMicroservice.Contracts.Data.Entities
{
    public class Customer : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public int Age { get; set; }
    }
}
