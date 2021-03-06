﻿using AutoMapper;
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

        public GetCommentByProductIdHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task<CommentListVm> Handle(GetCommentByProductIdQuery request, CancellationToken cancellationToken)
        {
            var commentList = await _fuhoDbContext.Comments
                .AsNoTracking()
                .Where(x => x.ProductId == request.ProductId)
                .OrderByDescending(x => x.CreateDate)
                .Select(x => new CommentDto 
                {
                    CommentId = x.CommentId,
                    Content = x.Content,
                    IsEdit = x.IsEdit,
                    Rating = x.Rating,
                })
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var commentListVm = new CommentListVm
            {
                CommentDtos = commentList
            };

            return commentListVm;
        }
    }
}
