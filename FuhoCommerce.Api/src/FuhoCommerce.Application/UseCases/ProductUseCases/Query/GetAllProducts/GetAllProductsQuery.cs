using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ProductListVm>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
