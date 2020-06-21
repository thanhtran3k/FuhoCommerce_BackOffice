using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public IList<ProductDto> Products { get; set; }
    }
}
