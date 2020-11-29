using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Domain.Entities
{
    public class Contact : BaseModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }      
        public ICollection<ContactInfo> ContactInfos { get; set; }
    }
}
