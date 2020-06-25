using AutoMapper;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Command.CreateCategory;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories;
using FuhoCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.Common.Mappings
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        }
    }
}
