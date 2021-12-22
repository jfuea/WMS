using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WMS.Application.Common.Exceptions;
using WMS.Application.Common.Interfaces;
using WMS.Domain.Entities;

namespace WMS.Application.ProductItems.Commands.UpdateProductItem
{
    public class UpdateProductItemCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }

    public class UpdateProductItemCommandHandler : IRequestHandler<UpdateProductItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductItem), request.Id);
            }
        
            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
