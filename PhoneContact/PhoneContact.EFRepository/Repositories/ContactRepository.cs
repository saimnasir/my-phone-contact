using Microsoft.EntityFrameworkCore;
using PhoneContact.Domain.Entities;
using PhoneContact.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneContact.EFRepository.Repositories
{

    public class ContactRepository : IContactRepository
    {
        private readonly PhoneContactContext _phoneContactContext;
        public IUnitOfWork UnitOfWork => _phoneContactContext;

        public ContactRepository(PhoneContactContext phoneContactContext)
        {
            _phoneContactContext = phoneContactContext;
        }

        public async Task<IEnumerable<Contact>> GetAsync()
        {
            return await _phoneContactContext.Contacts
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<Contact> GetAsync(long id)
        {
            var artist = await _phoneContactContext.Contacts
            .FindAsync(id);
            if (artist == null) return null;
            _phoneContactContext.Entry(artist).State = EntityState.Detached;
            return artist;
        }

        public Contact Add(Contact artist)
        {
            return _phoneContactContext.Contacts.Add(artist).Entity;
        }
    }

}
