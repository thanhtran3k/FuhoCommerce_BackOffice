using FuhoCommerce.Application.UseCases.CartUseCases.Query;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories;
using FuhoCommerce.Application.UseCases.OrderUserCases.Query;
using FuhoCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.Common.Extensions
{
    public static class ConvertDomainToEntity
    {
        #region Category

        public static CategoryDto ToCategoryEntity(this Category category)
        {
            var result = new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Thumbnail = category.Thumbnail
            };

            return result;
        }

        #endregion

        #region Cart

        public static CartDto ToCartEntity(this Cart cart)
        {
            var result = new CartDto
            {
                CartId = cart.CartId,
            };

            return result;
        }

        #endregion

        #region Cart

        public static OrderDto ToOrderEntity(this Order order)
        {
            var result = new OrderDto
            {
                 
            };

            return result;
        }

        #endregion
    }
}
