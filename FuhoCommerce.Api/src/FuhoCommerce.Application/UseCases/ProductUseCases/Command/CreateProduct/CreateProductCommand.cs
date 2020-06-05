using FuhoCommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Command.CreateProduct
{
    public class CreateProductCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; }
        public Guid CategoryId { get; set; }

        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public int Stock { get; set; }
        public int? ReorderLevel { get; set; }
        public ICollection<ProductOption> ProductOptions { get; set; }

    }
}
