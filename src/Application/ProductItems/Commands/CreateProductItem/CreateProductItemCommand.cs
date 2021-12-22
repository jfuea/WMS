using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.Application.Common.Interfaces;
using WMS.Domain.Entities;

namespace WMS.Application.ProductItems.Commands.CreateProductItem
{
    public class CreateProductItemCommand : IRequest<int>
    {
        public int ListId { get; set; }
        public string Name { get; set; }
    }

    public class CreateProductItemCommandHandler : IRequestHandler<CreateProductItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new ProductItem
            {
                ListId = request.ListId,
                Name = request.Name
            };

            _context.ProductItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
