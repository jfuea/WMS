using WMS.Application.Common.Interfaces;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using WMS.Domain.Entities;
using WMS.Domain.Enums;
using WMS.Application.Common.Exceptions;

namespace WMS.Application.ProductItems.Commands.UpdateProductItemDetail
{
    public class UpdateProductItemDetailCommand : IRequest
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public int MyProperty { get; set; }

        public ProductType Type { get; set; }

        public string Note { get; set; }

        public decimal SalesPrice { get; set; }

        public decimal Cost { get; set; }

        //public ProductCategory Category { get; set; }

        public string InternalReference { get; set; }

        public string Barcode { get; set; }

        public string Notes { get; set; }

        // 2. Inventory

        // TODO 2.1 Operations

        // 2.2 Logistics

        // TODO Responsible

        public decimal Weight { get; set; }

        public decimal Volume { get; set; }
        public decimal CustomerLeadTime { get; set; }

        // ---

        public int Quantity { get; set; }
        public int QuantityForecasted { get; set; }

    }

    public class UpdateProductItemDetailCommandHandler : IRequestHandler<UpdateProductItemDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductItemDetailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductItemDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductItems), request.Id);
            }

            entity.ListId = request.ListId;
            entity.Type = request.Type;
            entity.Note = request.Note;
            entity.SalesPrice = request.SalesPrice;
            entity.Cost = request.Cost;
            entity.InternalReference = request.InternalReference;
            entity.Barcode = request.Barcode;
            entity.Weight = request.Weight;
            entity.Volume = request.Volume;
            entity.CustomerLeadTime = request.CustomerLeadTime;
            entity.Quantity = request.Quantity;
            entity.QuantityForecasted = request.QuantityForecasted;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
