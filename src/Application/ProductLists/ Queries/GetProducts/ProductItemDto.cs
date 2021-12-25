using WMS.Application.Common.Mappings;
using WMS.Domain.Entities;
using WMS.Domain.Enums;

namespace WMS.Application.ProductLists.Queries.GetProducts
{
    public class ProductItemDto : IMapFrom<ProductItem>
    {
        public int Id { get; set; }

        public ProductList List { get; set; }

        public int ListId { get; set; }


        public string Name { get; set; }


        public ProductType Type { get; set; }

        public string Note { get; set; }

        public decimal SalesPrice { get; set; }

        public decimal Cost { get; set; }

        public string InternalReference { get; set; }

        public string Barcode { get; set; }

        public decimal Weight { get; set; }

        public decimal Volume { get; set; }
        public decimal CustomerLeadTime { get; set; }

        public int Quantity { get; set; }
        public int QuantityForecasted { get; set; }

    }
}
