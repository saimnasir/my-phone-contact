using PhoneContact.API.Client.Base;
using PhoneContact.API.Client.Resources;
using System.Net.Http;

namespace PhoneContact.API.Client
{
    public class PhoneContactClient : IPhoneContactClient
    {       
        public PhoneContactClient(HttpClient client)
        {
            Item = new PhoneContactContactResource(new BaseClient(client, client.BaseAddress.ToString()));
        }
        public IPhoneContactContactResource Item { get; }
    }
}
