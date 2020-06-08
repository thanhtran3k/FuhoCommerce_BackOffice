using FuhoCommerce.Application.Common.Exceptions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Command.RemoveCategory
{
    public class RemoveCategoryHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private readonly IFuhoDbContext _fuhoDbContext;
        public RemoveCategoryHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }
        public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _fuhoDbContext.Categories.FindAsync(request.CategoryId);

            if (result != null)
            {
                _fuhoDbContext.Categories.Remove(result);
                await _fuhoDbContext.SaveChangesAsync(cancellationToken);
            } else
            {
                throw new NullResult(nameof(Category), nameof(request.CategoryId));
            }

            return Unit.Value;
        }
    }
}
