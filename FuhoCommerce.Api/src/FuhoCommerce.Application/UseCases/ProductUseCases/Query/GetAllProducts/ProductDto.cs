﻿using FuhoCommerce.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public Guid CaterogyId { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public int Stock { get; set; }
        public string Images { get; set; }
        public string CategoryName { get; set; }

        public ICollection<ProductOption> ProductOptions { get; set; }
    }
}
