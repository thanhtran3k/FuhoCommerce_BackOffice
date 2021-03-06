﻿using FuhoCommerce.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProductsSC
{
    public class GetAllProductsSCHandler : IRequestHandler<GetAllProductsSCQuery, ProductsSCVm>
    {
        private readonly IFuhoDbContext _fuhoDbContext;

        public GetAllProductsSCHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }
        public async Task<ProductsSCVm> Handle(GetAllProductsSCQuery request, CancellationToken cancellationToken)
        {
            var productsSC = await _fuhoDbContext.Products
                .AsNoTracking()
                .Include(x => x.Category)
                .Where(x => x.CreatedBy == request.UserId)
                .Select(x => new ProductsSCDto
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    BrandName = x.BrandName,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    Price = x.Price,
                    Stock = x.Stock,
                    CreatedOn = x.CreateDate
                })
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();

            var result = new ProductsSCVm
            {
                productsSCDto = productsSC
            };

            return result;
        }
    }
}
