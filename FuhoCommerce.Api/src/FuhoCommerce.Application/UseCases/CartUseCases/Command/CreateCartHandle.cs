using FuhoCommerce.Application.Common.Extensions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using FuhoCommerce.Domain.Enumerations;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.CartUseCases.Command
{
    public class CreateCartHandle : IRequestHandler<CreateCartCommand, CreateCartResponse>
    {
        private readonly IFuhoDbContext _fuhoDbContext;
        public CreateCartHandle(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }
        public async Task<CreateCartResponse> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var cart = new Cart() 
                {
                    
                };

                _fuhoDbContext.Carts.Add(cart);

                await _fuhoDbContext.SaveChangesAsync(cancellationToken);

                return new CreateCartResponse
                {
                    ErrorCode = ResponseStatus.Success.ToInt(),
                    ErrorMessage = null,
                    ErrorMessageCode = null,
                    CartDto = cart.ToCartEntity()
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
