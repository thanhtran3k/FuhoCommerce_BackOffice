using MediatR;
using System;

namespace FuhoCommerce.Application.UseCases.SupplierUseCases.Command.CreateSupplier
{
    public class CreateSupplierCommand : IRequest
    {
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public int RatingReceived { get; set; }
    }
}
