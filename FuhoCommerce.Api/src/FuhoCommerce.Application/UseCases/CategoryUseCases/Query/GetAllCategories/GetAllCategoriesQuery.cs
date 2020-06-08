using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<CategoryListVm>
    {
    }
}
