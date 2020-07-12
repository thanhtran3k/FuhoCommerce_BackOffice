using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.CartUseCases.Command
{
    public class CreateCartCommand : IRequest<CreateCartResponse>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
