using FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories;
using FuhoCommerce.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Command.CreateCategory
{
    public class CreateCategoryResponse
    {
        public CategoryDto CategoryDto { get; set; }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorMessageCode { get; set; }


        public CreateCategoryResponse() { }

        public CreateCategoryResponse(CreateCategoryResponse other)
        {
            CategoryDto = other.CategoryDto != null ? other.CategoryDto : null;
            ErrorCode = other.ErrorCode;
            ErrorMessage = other.ErrorMessage;
            ErrorMessageCode = other.ErrorMessageCode;
        }
    }
}
