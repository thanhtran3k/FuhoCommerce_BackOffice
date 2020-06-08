using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.SupplierUseCases.Query.GetAllSuppliers
{
    public class SupplierListVm
    {
        public ICollection<SupplierDto> SupplierDtos { get; set; }
    }
}
