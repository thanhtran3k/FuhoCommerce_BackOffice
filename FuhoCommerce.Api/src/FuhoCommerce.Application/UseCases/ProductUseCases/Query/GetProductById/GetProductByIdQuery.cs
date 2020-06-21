using System;
using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProduct;
using MediatR;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public Guid ProductId{get; set;}
    }
}