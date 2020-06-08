using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Command.RemoveCategory
{
    public class RemoveCategoryCommand : IRequest
    {
        public Guid CategoryId { get; set; }
    }
}
