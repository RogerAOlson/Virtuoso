using ContactManager.Repositories;

namespace ContactManagerRepositoryDB.Models
{
    public class ContactManagerRepositoryContactSelectResult : IContactManagerRepositoryContactSelectResult
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}