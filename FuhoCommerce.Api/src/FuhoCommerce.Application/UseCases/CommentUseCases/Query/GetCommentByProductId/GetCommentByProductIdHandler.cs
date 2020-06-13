using AutoMapper;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Application.UseCases.CommentUseCases.Query.GetCommentByProductId;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.CommentsUseCases.Query.GetCommentByProductId
{
    public class GetCommentByProductIdHandler : IRequestHandler<GetCommentByProductIdQuery, CommentListVm>
    {
        private readonly IFuhoDbContext _fuhoDbContext;

        public GetCommentByProductIdHandler(IFuhoDbContext fuhoDbContext, IMapper mapper)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task<CommentListVm> Handle(GetCommentByProductIdQuery request, CancellationToken cancellationToken)
        {
            var commentList = await _fuhoDbContext.Products
                .Include(x => x.Comments)
                .Where(x => x.ProductId == request.ProductId)
                .Select(x => new CommentDto
                {
                   CommentId = x.Comments
                })
                .ToListAsync();


            //var productList = await _fuhoDbContext.Comments
            //    .OrderByDescending(x => x.CreateDate)
            //    .Select(x => new CommentDto
            //    {
            //       ProductId = x.Product.ProductId,
            //       CommentId = x.CommentId,
            //       Content = x.Content
            //    })
            //    .ToListAsync();

            var productListVm = new CommentListVm
            {
                CommentDtos = productList
            };

            return productListVm;
        }
    }
}
