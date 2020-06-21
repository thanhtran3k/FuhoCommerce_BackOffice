using MediatR;
using System;

namespace FuhoCommerce.Application.UseCases.ProductOptionUseCases.Command.CreateProductOption
{
    public class CreateProductOptionCommand : IRequest
    {
        public Guid ProductId { get; set; }

    }
}
