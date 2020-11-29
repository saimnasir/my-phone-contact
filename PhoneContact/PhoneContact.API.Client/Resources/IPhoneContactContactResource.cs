using PhoneContact.API.Contract.Item;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneContact.API.Client.Resources
{
    public interface IPhoneContactContactResource
    {
        Task<ContactResponse> Get(Guid id, CancellationToken cancellationToken = default);

    }
}
