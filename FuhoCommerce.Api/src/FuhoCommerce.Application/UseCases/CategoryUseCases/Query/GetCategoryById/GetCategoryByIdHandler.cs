using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly IFuhoDbContext _fuhoDbContext;
        private readonly ILogger<GetCategoryByIdHandler> _logger;

        public GetCategoryByIdHandler(IFuhoDbContext fuhoDbContext, ILogger<GetCategoryByIdHandler> logger)
        {
            _fuhoDbContext = fuhoDbContext;
            _logger = logger;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetCategoryByIdhandler - Get product by id");

            var result = await _fuhoDbContext.Categories
                .AsNoTracking()
                .Where(x => x.CategoryId == request.CategoryId)
                .Select(x => new CategoryDto
                {
                    CategoryId = x.CategoryId,
                    Name = x.Thumbnail,
                    Thumbnail = x.Thumbnail
                })
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return result;
        }
    }
}