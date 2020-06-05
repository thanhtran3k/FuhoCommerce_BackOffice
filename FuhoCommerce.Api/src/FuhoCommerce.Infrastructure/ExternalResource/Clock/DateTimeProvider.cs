using FuhoCommerce.CrossCuttingConcern;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Infrastructure.ExternalResource.Clock
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.UtcNow.ToLocalTime();
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
