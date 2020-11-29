using PhoneContact.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact.Domain.Repositories
{
    public interface IContactRepository : IRepository
    {
        Task<IEnumerable<Contact>> GetAsync();
        Task<Contact> GetAsync(long id);
        Contact Add(Contact item);
    }
}
