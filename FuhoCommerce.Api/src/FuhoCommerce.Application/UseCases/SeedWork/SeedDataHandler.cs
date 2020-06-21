using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.CrossCuttingConcern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.SeedWork
{
    public class SeedDataHandler : IRequestHandler<SeedDataCommand>
    {
        private readonly IFuhoDbContext _context;

        public SeedDataHandler(IFuhoDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SeedDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SeedData(_context);

            await seeder.CentrializedSeeding(cancellationToken);

            return Unit.Value;
        }
    }
}
