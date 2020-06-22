using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.Common.Exceptions
{
    public class ForbiddenAction : Exception
    {
        public ForbiddenAction(string action, string userId) : base($"Someone tried a forbidden action: {action} - from User: {userId} ")
        {
        }
    }
}
