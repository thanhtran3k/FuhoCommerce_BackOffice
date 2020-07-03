using FuhoCommerce.Application.Common.Exceptions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
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

            if (result == null) throw new NullResult(nameof(Comment), nameof(request.CommentId));

            if (request.UserId != result.CreatedBy) throw new ForbiddenAction(nameof(RemoveCommentCommand), request.UserId);

            _fuhoDbContext.Comments.Remove(result);
            await _fuhoDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
