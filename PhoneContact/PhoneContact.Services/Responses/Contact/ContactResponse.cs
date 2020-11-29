﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Services.Responses.Contact
{
    public class ContactResponse : BaseResponse
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
}
