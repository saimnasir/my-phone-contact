using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Domain.Repositories
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
