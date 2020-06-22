using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Command.RemoveProduct
{
    public class RemoveProductCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public string UserId { get; set; }
    }
}
