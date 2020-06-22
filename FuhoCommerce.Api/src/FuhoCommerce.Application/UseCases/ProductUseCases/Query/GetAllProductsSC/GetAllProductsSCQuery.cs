using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProductsSC
{
    public class GetAllProductsSCQuery : IRequest<ProductsSCVm>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string UserId { get; set; }
    }
}
