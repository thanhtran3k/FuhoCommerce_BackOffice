using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.CartUseCases.Query
{
    public class ProductCartDto
    {
        public Guid ProductCartId { get; set; }
        public ProductDto ProductDto { get; set; }
        public int Quantity { get; set; }
    }
}
