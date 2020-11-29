using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneContact.API.Client.Base
{
    public interface IBaseClient
    {
        Task<T> GetAsync<T>(Uri uri, CancellationToken cancellationToken);
        Uri BuildUri(string format);
    }
}
