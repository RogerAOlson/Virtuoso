namespace ContactManager.Repositories
{
    public interface IContactManangerRepository :
        IContactManangerRepositoryContactSelect,
        IContactManangerRepositoryContactDelete,
        IContactManangerRepositoryContactUpdate,
        IContactManangerRepositoryContactAdd
    {
    }
}
