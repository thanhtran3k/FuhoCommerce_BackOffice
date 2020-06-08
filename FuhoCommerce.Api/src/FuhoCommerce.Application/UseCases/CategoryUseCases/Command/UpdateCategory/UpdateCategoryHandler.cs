using FuhoCommerce.Application.Common.Exceptions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Command.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand>
    {    
        private readonly IFuhoDbContext _fuhoDbContext;
        private readonly ILogger<UpdateCategoryHandler> _logger;

        public UpdateCategoryHandler(IFuhoDbContext fuhoDbContext, ILogger<UpdateCategoryHandler> logger)
        {
            _fuhoDbContext = fuhoDbContext;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _fuhoDbContext.Categories.FindAsync(request.CategoryId);

                if (category != null)
                {
                    //Save category
                    category.Name = request.Name;
                    category.Thumbnail = request.Thumbnail;

                    _fuhoDbContext.Categories.Update(category);
                    await _fuhoDbContext.SaveChangesAsync(cancellationToken);

                    return Unit.Value;
                }
                else
                {
                    throw new NullResult(nameof(Category), nameof(request.CategoryId));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}