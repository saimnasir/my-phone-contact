using PhoneContact.Domain.Entities;
using PhoneContact.Services.Responses.Contact;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Services.Mappers
{
    public interface IContactMapper
    {
        ContactResponse Map(Contact contact);

    }
}
