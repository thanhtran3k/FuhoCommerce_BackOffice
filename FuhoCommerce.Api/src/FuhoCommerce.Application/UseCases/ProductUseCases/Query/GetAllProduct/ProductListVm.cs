using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProduct
{
    public class ProductListVm
    {
        public ICollection<ProductDto> ProductDtos { get; set; }
    }
}
