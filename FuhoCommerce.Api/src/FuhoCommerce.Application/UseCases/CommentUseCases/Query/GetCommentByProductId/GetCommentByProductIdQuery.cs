using MediatR;
using System;

namespace FuhoCommerce.Application.UseCases.CommentUseCases.Query.GetCommentByProductId
{
    public class GetCommentByProductIdQuery : IRequest<CommentListVm>
    {
        public Guid ProductId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
