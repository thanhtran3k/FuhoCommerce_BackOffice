using FuhoCommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Command.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
    }
}