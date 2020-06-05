using System;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public int Stock { get; set; }
    }
}
