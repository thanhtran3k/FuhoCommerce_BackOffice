using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Common
{
    public class BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}
