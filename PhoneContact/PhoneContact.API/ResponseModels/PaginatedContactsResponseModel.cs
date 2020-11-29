using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneContact.API.ResponseModels
{
    public class PaginatedContactsResponseModel<TEntity> where TEntity : class
    {
        public PaginatedContactsResponseModel(int pageIndex, int pageSize, long total, IEnumerable<TEntity> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize; Total = total;
            Data = data;
        }
        public int PageIndex { get; }
        public int PageSize { get; }
        public long Total { get; }
        public IEnumerable<TEntity> Data { get; }
    }
}
