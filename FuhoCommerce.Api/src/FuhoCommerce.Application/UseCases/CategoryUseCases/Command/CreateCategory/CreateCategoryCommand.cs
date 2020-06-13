using FuhoCommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Command.CreateCategory
{
    public class CreateCategoryCommand : IRequest
    {
        public string Name { get; set; }
        public string Thumbnail { get; set; }
    }
}
