using System;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories;
using MediatR;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public Guid CategoryId{get; set;}
    }
}