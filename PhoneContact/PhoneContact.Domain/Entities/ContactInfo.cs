using PhoneContact.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Domain.Entities
{
    public class ContactInfo : BaseModel
    {
        public long Contact { get; set; }
        public InfoType InfoType { get; set; }
        public string Information { get; set; }
    }
}
