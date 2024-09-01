using ContactManager.Models;
using ContactManager.Repositories;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace ContactManagerRepositoryDB
{
    public partial class Repository : IContactManagerRepositoryContactDelete
    {
        public async Task ContactDeleteAsync(int contactId, ILogger logger)
        {
            SqlConnection? conn = null;

            try
            {
                conn = CreateConnection();
                conn.Open();
                var cmd = new SqlCommand("sp_ContactDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ContactId", contactId));

                var rowsEffected = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                if(rowsEffected != 1)
                {
                    throw new RecordNotFoundException();
                }
            }
            catch(RecordNotFoundException)
            {
                logger.Log(LogLevel.Error, "Attempting to delete missing Contact {ContactId}", contactId);
                throw;
            }
            catch(Exception)
            {
                logger.Log(LogLevel.Error, "Unexpected error while deleting contact {ContactId}", contactId);
                throw new RepositoryException();
            }
            finally
            {
                conn?.Close();
            }
        }
    }
}
