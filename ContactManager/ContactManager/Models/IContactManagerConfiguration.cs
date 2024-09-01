namespace ContactManager.Models
{
    public interface IContactManagerConfiguration :
        IContactManagerRepositoryConfiguration
    {
    }

    public interface IContactManagerRepositoryConfiguration
    {
        public string ConnectionString { get; }
    }
}
