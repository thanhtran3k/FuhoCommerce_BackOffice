using MediatR;
using System;

namespace FuhoCommerce.Application.UseCases.ProductOptionUseCases.Command.UpdateProductOption
{
    public class UpdateProductOptionCommand : IRequest
    {
        public Guid ProductOptionId { get; set; }

    }
}