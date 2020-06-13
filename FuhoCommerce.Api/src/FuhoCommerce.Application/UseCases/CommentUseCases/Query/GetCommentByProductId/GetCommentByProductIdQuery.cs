using MediatR;

namespace FuhoCommerce.Application.UseCases.CommentUseCases.Query.GetCommentByProductId
{
    public class GetCommentByProductIdQuery : IRequest<CommentListVm>
    {
        public Guid ProductId { get; set; }
    }
}
