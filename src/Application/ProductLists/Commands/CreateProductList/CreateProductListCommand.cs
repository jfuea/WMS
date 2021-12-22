using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.Application.Common.Interfaces;
using WMS.Domain.Entities;

namespace WMS.Application.ProductLists.Commands.CreateProductList
{
    public class CreateProductListCommand : IRequest<int>
    {
        public string Title { get; set; }

    }

    public class CreateProductListCommandHandler : IRequestHandler<CreateProductListCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductListCommand request, CancellationToken cancellationToken)
        {
            var entity = new ProductList();
            entity.Title = request.Title;

            _context.ProductLists.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
