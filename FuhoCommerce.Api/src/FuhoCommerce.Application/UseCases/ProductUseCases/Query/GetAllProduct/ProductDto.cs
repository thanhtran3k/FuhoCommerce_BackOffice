using System;
using System.Collections;
using System.Collections.Generic;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProduct
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public int Stock { get; set; }

        public IList<ProductOptionDto> ProductOption { get; set; }
    }
}
