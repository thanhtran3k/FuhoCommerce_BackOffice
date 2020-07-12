using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.CartUseCases.Query
{
    public class CartDto
    {
        public Guid CartId { get; set; }

        public ICollection<ProductCartDto> ProductCartDtos { get; set; }

    }
}
