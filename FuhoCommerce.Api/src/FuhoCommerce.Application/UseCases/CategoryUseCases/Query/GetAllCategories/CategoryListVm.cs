using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories
{
    public class CategoryListVm
    {
        public ICollection<CategoryDto> CategoryDtos { get; set; }
    }
}
