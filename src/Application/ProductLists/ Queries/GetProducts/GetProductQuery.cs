using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.Application.Common.Interfaces;

namespace WMS.Application.ProductLists.Queries.GetProducts
{
    public class GetProductQuery : IRequest<ProductsVm>
    {
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductsVm> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return new ProductsVm
            {
                Lists = await _context.ProductLists
                    .ProjectTo<ProductListDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
