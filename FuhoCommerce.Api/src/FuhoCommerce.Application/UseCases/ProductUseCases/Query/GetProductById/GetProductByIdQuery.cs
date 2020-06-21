using System;
using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts;
using MediatR;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public Guid ProductId{get; set;}
    }
}