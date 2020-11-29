using Dapper;
using PhoneContact.Domain.Entities;
using PhoneContact.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact.DapperRepository
{
    public class ContactRepository : IContactRepository
    {
        private readonly SqlConnection _sqlConnection;
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public ContactRepository(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
        }
        public async Task<IEnumerable<Contact>> GetAsync()
        {
            var result = await _sqlConnection.QueryAsync<Contact>
                                 ("GetAllBooks", commandType:
                                 CommandType.StoredProcedure);
            return result.AsList();
        }

        public async Task<Contact> GetAsync(long id)
        {
            return await _sqlConnection.ExecuteScalarAsync<Contact>
              ("GetAllBooks", new { Id = id.ToString() }, commandType:
              CommandType.StoredProcedure);
        }

        public Contact Add(Contact contact)
        {
            var result = _sqlConnection.ExecuteScalar<Contact>
                      ("InsertBook", contact, commandType: CommandType.StoredProcedure);
            return result;
        }

    }
}
