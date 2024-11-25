namespace Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Entities
{
    public class Person
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public bool IsCustomer { get; private set; }

        public Person(string name, string email, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Phone = phone;
            IsCustomer = false;
        }

        public void PromoteToCustomer()
        {
            IsCustomer = true;
        }
    }

}
