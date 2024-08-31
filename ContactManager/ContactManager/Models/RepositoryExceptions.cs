namespace ContactManager.Models
{
    public class RepositoryExceptions : Exception
    {
    }

    public class RecordAlreadyExistsException : RepositoryExceptions
    {
    }

    public class RecordNotFoundException : RepositoryExceptions
    {
    }
}
