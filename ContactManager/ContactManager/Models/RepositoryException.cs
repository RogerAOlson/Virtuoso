namespace ContactManager.Models
{
    public class RepositoryException : Exception
    {
    }

    public class RecordAlreadyExistsException : RepositoryException
    {
    }

    public class RecordNotFoundException : RepositoryException
    {
    }
}
