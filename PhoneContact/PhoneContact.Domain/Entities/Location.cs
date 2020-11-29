using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Domain.Entities
{
   public class Location: BaseModel
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
