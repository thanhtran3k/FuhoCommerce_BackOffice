using MediatR;
using System;

namespace FuhoCommerce.Application.UseCases.ProductOptionUseCases.Command.RemoveProductOption
{
    public class RemoveProductOptionCommand : IRequest
    {
        public Guid ProductOptionId { get; set; }
    }
}
