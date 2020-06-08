using AutoMapper;
using FuhoCommerce.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, CategoryListVm>
    {
        private readonly IFuhoDbContext _fuhoDbContext;

        public GetAllCategoriesHandler(IFuhoDbContext fuhoDbContext, IMapper mapper)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task<CategoryListVm> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var productList = await _fuhoDbContext.Categories
                .OrderByDescending(x => x.Name)
                .Select(x => new CategoryDto
                {
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Thumbnail = x.Thumbnail
                })
                .ToListAsync();

            var productListVm = new CategoryListVm
            {
                CategoryDtos = productList
            };

            return productListVm;
        }
    }
}
