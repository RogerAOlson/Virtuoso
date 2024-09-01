using ContactManager.Models;
using ContactManager.Repositories;
using ContactManagerRepositoryDB.Models;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Data;

namespace ContactManagerRepositoryDB
{
    public partial class Repository : IContactManagerRepositoryContactSelect
    {
        public async Task<IContactManagerRepositoryContactSelectResult?> ContactSelectAsync(int contactId, ILogger logger)
        {
            SqlConnection? conn = null;

            try
            {
                conn = CreateConnection();
                await conn.OpenAsync().ConfigureAwait(false);

                var cmd = new SqlCommand("sp_Contact", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ContactId", contactId));

                using var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
                if (reader.HasRows && await reader.ReadAsync().ConfigureAwait(false))
                {
                    var result = new ContactManagerRepositoryContactSelectResult()
                    {
                        Id = (int)reader["ContactId"],
                        FirstName = reader.IsDBNull("FirstName") ? null : (string)reader["FirstName"],
                        LastName = reader.IsDBNull("LastName") ? null : (string)reader["LastName"],
                        Email = reader.IsDBNull("Email") ? null : (string)reader["Email"],
                        PhoneNumber = reader.IsDBNull("PhoneNumber") ? null : (string)reader["PhoneNumber"],
                    };
                    return result;
                }

                return null;
            }
            catch (Exception)
            {
                logger.Log(LogLevel.Error, "Unexpected error while getting contact {ContactId}", contactId);
                throw new RepositoryException();
            }
            finally
            {
                conn?.Close();
            }
        }
    }
}