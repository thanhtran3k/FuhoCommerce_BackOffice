using FuhoCommerce.Application.Common.Exceptions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.CommentUseCases.Command.UpdateComment
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand>
    {    
        private readonly IFuhoDbContext _fuhoDbContext;
        private readonly ILogger<UpdateCommentHandler> _logger;

        public UpdateCommentHandler(IFuhoDbContext fuhoDbContext, ILogger<UpdateCommentHandler> logger)
        {
            _fuhoDbContext = fuhoDbContext;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var comment = await _fuhoDbContext.Comments.FindAsync(request.CommentId);

                if (comment == null) throw new NullResult(nameof(Comment), nameof(request.CommentId));

                if (request.UserId != comment.CreatedBy) throw new ForbiddenAction(nameof(UpdateCommentCommand), request.UserId);

                comment.Content = request.Content;
                comment.IsEdit = true;
                comment.Rating = request.Rating;

                _fuhoDbContext.Comments.Update(comment);
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