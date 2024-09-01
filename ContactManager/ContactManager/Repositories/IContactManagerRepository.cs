namespace ContactManager.Repositories
{
    public interface IContactManagerRepository :
        IContactManagerRepositoryContactSelect,
        IContactManagerRepositoryContactDelete,
        IContactManagerRepositoryContactUpdate,
        IContactManagerRepositoryContactAdd
    {
    }
}
