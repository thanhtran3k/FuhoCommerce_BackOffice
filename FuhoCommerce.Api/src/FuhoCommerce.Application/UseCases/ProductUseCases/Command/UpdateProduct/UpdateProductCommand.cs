using FuhoCommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Command.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public string UserId { get; set; }

        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public int Stock { get; set; }
        public IFormFile File { get; set; }

        public ICollection<ProductOption> ProductOptions { get; set; }
    }
}