using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.Common.Exceptions
{
    public class NullResult : Exception
    {
        public NullResult(string nullObject, object key) : base($"Can not find {nullObject} with key = {key}.")
        {
        }
    }
}
