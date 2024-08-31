using ContactManagerRepository.Models;

namespace ContactManagerRepository.Repository.ContactManager
{
    public partial class Repository
    {
        static Repository()
        {
            Table = new Dictionary<int, ContactTuple>
            {
                { 100, new ContactTuple { Id = 100, FirstName = "Test", LastName = "User", Email = "a@b.c", PhoneNumber = "123 456-7890" } }
            };
            NextId = 101;
        }

        private static int NextId { get; set; }
        private static Dictionary<int, ContactTuple> Table { get; set; }
    }
}
