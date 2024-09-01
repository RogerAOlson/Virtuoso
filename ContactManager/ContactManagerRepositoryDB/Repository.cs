using ContactManager.Models;
using System.Data.SqlClient;

namespace ContactManagerRepositoryDB
{
    public partial class Repository
    {
        public Repository(IContactManagerRepositoryConfiguration configuration)
        {
            this.ConnectionString = configuration.ConnectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        private string ConnectionString { get; set; }
    }
}
