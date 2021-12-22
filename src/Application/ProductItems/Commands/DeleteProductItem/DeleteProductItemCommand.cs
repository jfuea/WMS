using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.Application.Common.Exceptions;
using WMS.Application.Common.Interfaces;
using WMS.Domain.Entities;

namespace WMS.Application.ProductItems.Commands.DeleteProductItem
{
    public class DeleteProductItemCommand : IRequest
    {
        public int Id{ get; set; }
    }

    public class DeleteProductItemCommandHandler : IRequestHandler<DeleteProductItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductItem), request.Id);
            }

            _context.ProductItems.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
