namespace Tweb.Digital.Marketing.Leads.Api.Domain.Persons.Entities
{
    public class Person
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        private Person() { }
        public Person(Guid id, string name, string email, string phone, DateTime createdAt, DateTime? updatedAt)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Person Create(string name, string email, string phone)
        {
            return new Person()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Phone = phone,
                CreatedAt = DateTime.Now,
            };
        }
    }

}
