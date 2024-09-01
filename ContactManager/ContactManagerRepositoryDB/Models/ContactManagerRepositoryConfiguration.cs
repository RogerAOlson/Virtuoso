using ContactManager.Models;

namespace ContactManagerRepositoryDB.Models
{
    public class ContactManagerRepositoryConfiguration : IContactManagerRepositoryConfiguration
    {
        public string? ContactManagerRepositoryConnectionString { get; set; }
    }
}
