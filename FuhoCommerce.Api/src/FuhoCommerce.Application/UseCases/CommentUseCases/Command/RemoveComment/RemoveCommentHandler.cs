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

namespace FuhoCommerce.Application.UseCases.CommentUseCases.Command.RemoveComment
{
    public class RemoveCommentHandler : IRequestHandler<RemoveCommentCommand>
    {
        private readonly IFuhoDbContext _fuhoDbContext;
        public RemoveCommentHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }
        public async Task<Unit> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var result = await _fuhoDbContext.Comments.FindAsync(request.CommentId);

            if (result != null)
            {
                _fuhoDbContext.Comments.Remove(result);
                await _fuhoDbContext.SaveChangesAsync(cancellationToken);
            } else
            {
                throw new NullResult(nameof(Comment), nameof(request.CommentId));
            }

            return Unit.Value;
        }
    }
}
