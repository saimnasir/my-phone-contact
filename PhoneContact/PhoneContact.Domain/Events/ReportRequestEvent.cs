using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Domain.Events
{
    public class ReportRequestEvent : IntegrationEvent
    {
        public string ReportId { get; set; }

        public ReportRequestEvent(string reportId)
        {
            ReportId = reportId;
        }
    }
}
