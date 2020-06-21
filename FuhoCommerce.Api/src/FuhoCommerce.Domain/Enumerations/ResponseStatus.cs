using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Enumerations
{
    public enum ResponseStatus
    {
        Success = 0,
        Fail = 10,
        Invalid = 20,
        Valid = 30,
        Available = 40,
        NotAvailable = 50,
        FailWithException = 60,
        InProgress = 70,
        Completed = 80
    }

    public class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorMessageCode { get; set; }
    }
}
