using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts
{
    public class ProductListVm
    {
        public ICollection<ProductDto> ProductDtos { get; set; }
    }
}
