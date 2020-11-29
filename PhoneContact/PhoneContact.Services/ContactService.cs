using PhoneContact.Domain.Entities;
using PhoneContact.Domain.Repositories;
using PhoneContact.Services.Contracts;
using PhoneContact.Services.Mappers;
using PhoneContact.Services.Requests;
using PhoneContact.Services.Responses.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactMapper _contactMapper;

        public ContactService(IContactRepository contactRepository, IContactMapper contactMapper)
        {
            _contactRepository = contactRepository;
            _contactMapper = contactMapper;
        }
        public async Task<IEnumerable<ContactResponse>> GetContactsAsync()
        {
            
            var result = await _contactRepository.GetAsync();
            return result.Select(_contactMapper.Map);
        }

        public async Task<ContactResponse> GetContactAsync(GetContactRequest request)
        {
            if (request?.Id == null) throw new ArgumentNullException();
            var result = await _contactRepository.GetAsync(request.Id);
            return result == null ? null : _contactMapper.Map(result);
        }

        public async Task<ContactResponse> AddContactAsync(AddContactRequest request)
        {
            var item = new Contact
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                // ...
            };
            var result = _contactRepository.Add(item);
            await _contactRepository.UnitOfWork.SaveChangesAsync();
            return _contactMapper.Map(result);
        }
    }
}
