using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProduct
{
    public class ProductOptionDto
    {
        public Guid ProductOptionId { get; set; }
        public string Optionkey { get; set; }
        public string OptionValues { get; set; }
    }
}
