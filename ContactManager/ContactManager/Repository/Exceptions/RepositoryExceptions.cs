namespace ContactManager.Repository.Exceptions
{
    public class RepositoryExceptions : IOException
    {
    }

    public class RecordAlreadyExistsException : RepositoryExceptions
    {
    }

    public class  RecordNotFoundException : RepositoryExceptions
    {
    }
}
