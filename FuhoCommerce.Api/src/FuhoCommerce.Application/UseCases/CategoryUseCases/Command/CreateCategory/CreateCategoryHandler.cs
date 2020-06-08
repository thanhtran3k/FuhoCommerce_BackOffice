using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Command.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand>
    {
        public readonly IFuhoDbContext _fuhoDbContext;

        public CreateCategoryHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
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

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
