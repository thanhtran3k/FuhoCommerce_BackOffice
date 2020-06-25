using AutoMapper;
using FuhoCommerce.Application.Common.Extensions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using FuhoCommerce.Domain.Enumerations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Command.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
    {
        public readonly IFuhoDbContext _fuhoDbContext;
        public readonly IMapper _mapper;

        public CreateCategoryHandler(IFuhoDbContext fuhoDbContext, IMapper mapper)
        {
            _fuhoDbContext = fuhoDbContext;
            _mapper = mapper;
        }

        public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newCategory = new Category()
                {
                    Name = request.Name,
                    Thumbnail = request.Thumbnail
                };

                _fuhoDbContext.Categories.Add(newCategory);

                await _fuhoDbContext.SaveChangesAsync(cancellationToken);

                return new CreateCategoryResponse 
                {
                    ErrorCode = ResponseStatus.Success.ToInt(),
                    ErrorMessage = null,
                    ErrorMessageCode = null,
                    CategoryDto = newCategory.ToCategoryEntity()
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
