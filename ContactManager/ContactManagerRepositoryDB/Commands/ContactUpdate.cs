using ContactManager.Models;
using Microsoft.Extensions.Logging;
using ContactManager.Repositories;
using System.Data.SqlClient;
using System.Data;

namespace ContactManagerRepositoryDB
{
    public partial class Repository : IContactManagerRepositoryContactUpdate
    {
        public async Task ContactUpdateAsync(ContactUpdate model, ILogger logger)
        {
            SqlConnection? conn = null;

            try
            {
                conn = CreateConnection();
                await conn.OpenAsync().ConfigureAwait(false);

                var cmd = new SqlCommand("sp_ContactUpdate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ContactId", model.Id));
                cmd.Parameters.Add(new SqlParameter("@FirstName", model.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LastName", model.LastName));
                cmd.Parameters.Add(new SqlParameter("@Email", model.Email));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", model.PhoneNumber));

                var rowsEffected = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                if (rowsEffected != 1)
                {
                    throw new RecordNotFoundException();
                }
            }
            catch (RecordNotFoundException)
            {
                logger.Log(LogLevel.Error, "Attempting to update missing Contact {ContactId}", model.Id);
                throw;
            }
            catch (Exception)
            {
                logger.Log(LogLevel.Error, "Unexpected error while updating contact {ContactId}", model.Id);
                throw new RepositoryException();
            }
            finally
            {
                conn?.Close();
            }
        }
    }
}
