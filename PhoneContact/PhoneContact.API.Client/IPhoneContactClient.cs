using PhoneContact.API.Client.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.API.Client
{
    public interface IPhoneContactClient
    {
        IPhoneContactContactResource Item { get; }
    }
}
