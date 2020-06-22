using FuhoCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProductsSC
{
    public class ProductsSCDto
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }

        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
