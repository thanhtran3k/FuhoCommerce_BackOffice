using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.CommentUseCases.Query.GetCommentByProductId
{
    public class CommentListVm
    {
        public ICollection<CommentDto> CommentDtos { get; set; }
    }
}
