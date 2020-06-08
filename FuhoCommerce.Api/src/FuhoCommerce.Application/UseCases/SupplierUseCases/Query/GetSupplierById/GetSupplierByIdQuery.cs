using System;
using FuhoCommerce.Application.UseCases.SupplierUseCases.Query.GetAllSuppliers;
using MediatR;

namespace FuhoCommerce.Application.UseCases.SupplierUseCases.Query.GetSupplierById
{
    public class GetSupplierByIdQuery : IRequest<SupplierDto>
    {
        public Guid SupplierId{get; set;}
    }
}