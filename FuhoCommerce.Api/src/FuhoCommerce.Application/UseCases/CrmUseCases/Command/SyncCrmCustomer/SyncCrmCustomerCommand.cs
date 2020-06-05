using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.CrmUseCases.Command.SyncCrmCustomer
{
    public class SyncCrmCustomerCommand : IRequest
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public bool IsSupplier { get; set; }
    }
}
