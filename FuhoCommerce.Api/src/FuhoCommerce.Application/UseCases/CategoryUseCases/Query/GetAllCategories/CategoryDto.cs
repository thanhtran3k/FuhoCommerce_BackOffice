using System;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
    }
}
