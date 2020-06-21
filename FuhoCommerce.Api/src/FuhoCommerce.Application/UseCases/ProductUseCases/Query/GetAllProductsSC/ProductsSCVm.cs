using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProductsSC
{
    public class ProductsSCVm
    {
        public ICollection<ProductsSCDto> productsSCDto { get; set; }
    }
}
