using ContactManager.Models;
using Microsoft.Extensions.Logging;
using ContactManager.Repositories;
using System.Data.SqlClient;
using System.Data;

namespace ContactManagerRepositoryDB
{
    public partial class Repository : IContactManangerRepositoryContactAdd
    {
        public async Task<int> ContactAddAsync(ContactAdd model, ILogger logger)
        {
            SqlConnection? conn = null;

            try
            {
                conn = CreateConnection();
                await conn.OpenAsync().ConfigureAwait(false);

                var cmd = new SqlCommand("sp_ContactInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FirstName", model.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LastName", model.LastName));
                cmd.Parameters.Add(new SqlParameter("@Email", model.Email));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", model.PhoneNumber));

                var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
                if(reader.HasRows && await reader.ReadAsync().ConfigureAwait(false))
                {
                    var contactId = reader.GetFieldValue<int>("ContactId");
                    return contactId;
                }

                logger.Log(LogLevel.Error, "Unexpected error while adding contact");
                throw new RepositoryException();
            }
            catch (Exception)
            {
                logger.Log(LogLevel.Error, "Unexpected error while adding contact");
                throw new RepositoryException();
            }
            finally
            {
                conn?.Close();
            }
        }
    }
}
