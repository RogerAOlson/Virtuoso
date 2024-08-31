namespace ContactManager.Repository.ContactManager
{
    public interface IContactManangerRepository :
        IContactManangerRepositoryContactSelect,
        IContactManangerRepositoryContactDelete,
        IContactManangerRepositoryContactUpdate,
        IContactManangerRepositoryContactAdd
    {
    }
}
