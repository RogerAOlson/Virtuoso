using ContactManagerRepositoryDict.Models;

namespace ContactManagerRepositoryDict
{
    public partial class Repository
    {
        public Repository()
        { }

        static Repository()
        {
            Table = new Dictionary<int, ContactTuple>
            {
                { 100, new ContactTuple { Id = 100, FirstName = "Test", LastName = "User", Email = "a@b.c", PhoneNumber = "123 456-7890" } }
            };
            NextId = 101;
        }

        public static int NextId { get; set; }
        public static Dictionary<int, ContactTuple> Table { get; set; }
    }
}
