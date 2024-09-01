using ContactManager.Models;

namespace ContactManagerRepositoryDict.Models
{
    public class ContactManagerConfiguration : IContactManagerConfiguration
    {
        public string ConnectionString { get; set; }
    }
}
