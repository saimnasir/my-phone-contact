using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Services.Responses
{
    public class BaseResponse
    {
        public long Id { get; set; }
        public Guid UIID { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
