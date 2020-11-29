using PhoneContact.API.Client.Base;
using PhoneContact.API.Contract.Item;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneContact.API.Client.Resources
{
    public class PhoneContactContactResource : IPhoneContactContactResource
    {
        private readonly IBaseClient _client;

        public PhoneContactContactResource(IBaseClient client)
        {
            _client = client;
        }

        public async Task<ContactResponse> Get(Guid id, CancellationToken cancellationToken = default)
        {
            var uri = BuildUri(id);
            return await _client.GetAsync<ContactResponse>(uri, cancellationToken);
        }

        private Uri BuildUri(Guid id, string path = "")
        {
            return _client.BuildUri(string.Format("api/contacts/{0}", id, path));
        }
    }
}
