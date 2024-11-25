namespace Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Models
{
    public class DbPersonModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsCustomer { get; set; }
    }
}
