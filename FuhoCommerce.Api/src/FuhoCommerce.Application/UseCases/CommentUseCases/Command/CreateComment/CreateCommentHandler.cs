using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.CommentUseCases.Command.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand>
    {
        public readonly IFuhoDbContext _fuhoDbContext;

        public CreateCommentHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _fuhoDbContext.Products.Where(x => x.ProductId == request.ProductId).ToList();

                if (product.Any())
                {
                    var newComment = new Comment()
                    {
                       Content = request.Content,
                       ProductId = request.ProductId,
                       IsEdit = false
                    };

                    _fuhoDbContext.Comments.Add(newComment);

                    await _fuhoDbContext.SaveChangesAsync(cancellationToken);
                }

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
