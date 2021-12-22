using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.Application.Common.Exceptions;
using WMS.Application.Common.Interfaces;

namespace WMS.Application.ProductLists.Commands.DeleteProductList
{
    public class DeleteProductListCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteProductListCommandHandler : IRequestHandler<DeleteProductListCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductLists
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductLists), request.Id);
            }

            _context.ProductLists.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
