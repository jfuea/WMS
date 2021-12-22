using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.Application.Common.Exceptions;
using WMS.Application.Common.Interfaces;

namespace WMS.Application.ProductLists.Commands.UpdateteProductList
{
    public class UpdateProductListCommand : IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }

    public class UpdateProductListCommandHandler : IRequestHandler<UpdateProductListCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductLists.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductLists), request.Id);
            }

            entity.Title = request.Title;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
