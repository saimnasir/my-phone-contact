using PhoneContact.Domain.Entities;
using PhoneContact.Services.Responses.Contact;

namespace PhoneContact.Services.Mappers
{
    public class ContactMapper : IContactMapper
    {
        public ContactResponse Map(Contact contact)
        {
            if (contact == null) return null;
            return new ContactResponse
            {
                Id = contact.Id,
                UIID = contact.UIID,
                CreateDate = contact.CreateDate,
                UpdateDate = contact.UpdateDate,
                IsDeleted = contact.IsDeleted,
                FirstName = contact.FirstName,
                MiddleName = contact.FirstName,
                LastName = contact.FirstName,
                CompanyName = contact.FirstName,
            };
        }
 
    }
}
