using AutoMapper;
using FuhoCommerce.Application.Common.Extensions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using FuhoCommerce.Domain.Enumerations;
using MediatR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.OrderUserCases.Command
{
    public class CreateOrderHandle : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        public readonly IFuhoDbContext _fuhoDbContext;
        public readonly IMapper _mapper;
        public readonly List<OrderDetail> listOrderDetail;

        public CreateOrderHandle(IFuhoDbContext fuhoDbContext, IMapper mapper)
        {
            _fuhoDbContext = fuhoDbContext;
            _mapper = mapper;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // add order
                var orderId = new Guid();
                var newOrder = new Order
                {
                    OrderId = orderId,
                    ShipName = request.ShipName,
                    ShipAddress = request.ShipAddress,
                    ShipCity = request.ShipCity,
                    ShipCountry = request.ShipCountry
                };

                // add order detail
                foreach (var item in request.OrderDetails)
                {
                    var newOrderDetail = new OrderDetail
                    {
                        ProductId = item.ProductId,
                        OrderId = orderId,
                        UnitPrice = item.UnitPrice,
                        Quantity = item.Quantity,
                        Discount = item.Discount
                    };
                    listOrderDetail.Add(newOrderDetail);
                }


                _fuhoDbContext.Orders.AddRange(newOrder);
                _fuhoDbContext.OrderDetails.AddRange(listOrderDetail);

                await _fuhoDbContext.SaveChangesAsync(cancellationToken);

                return new CreateOrderResponse
                {
                    ErrorCode = ResponseStatus.Success.ToInt(),
                    ErrorMessage = null,
                    ErrorMessageCode = null,
                    OrderDto = newOrder.ToOrderEntity()
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
