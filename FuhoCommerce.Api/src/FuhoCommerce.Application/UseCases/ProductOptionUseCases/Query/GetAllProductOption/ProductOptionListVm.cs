using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.ProductOptionUseCases.Query.GetAllProductOption
{
    public class ProductOptionListVm
    {
        public ICollection<ProductOptionDto> ProductOptionDtos { get; set; }
    }
}
