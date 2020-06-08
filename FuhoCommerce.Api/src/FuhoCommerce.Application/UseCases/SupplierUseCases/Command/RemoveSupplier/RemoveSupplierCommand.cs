using MediatR;
using System;

namespace FuhoCommerce.Application.UseCases.SupplierUseCases.Command.RemoveSupplier
{
    public class RemoveSupplierCommand : IRequest
    {
        public Guid SupplierId { get; set; }
    }
}
