using PhoneContact.Services.Requests;
using PhoneContact.Services.Responses.Contact;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact.Services.Contracts
{
    public interface IContactService
    {
        Task<IEnumerable<ContactResponse>> GetContactsAsync();
        Task<ContactResponse> GetContactAsync(GetContactRequest request);
        Task<ContactResponse> AddContactAsync(AddContactRequest request);
    }
}
