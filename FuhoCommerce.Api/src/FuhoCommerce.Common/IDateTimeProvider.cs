using System;

namespace FuhoCommerce.CrossCuttingConcern
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }

        DateTime UtcNow { get; }

        //In C# 8.0, Can implement inside interface
        public int Year => DateTime.Now.Year;
    }
}
