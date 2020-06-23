using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Application.UseCases.CommentUseCases.Query.GetCommentByProductId;
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
                var newComment = new Comment()
                {
                    ProductId = request.ProductId,
                    Content = request.Content,
                    Rating = request.Rating
                };

                _fuhoDbContext.Comments.Add(newComment);
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
