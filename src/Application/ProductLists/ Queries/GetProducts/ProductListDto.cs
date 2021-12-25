using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Application.Common.Mappings;
using WMS.Domain.Entities;

namespace WMS.Application.ProductLists.Queries.GetProducts
{
    public class ProductListDto : IMapFrom<ProductList>
    {
        public ProductListDto()
        {
            Items = new List<ProductItemDto>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public IList<ProductItemDto> Items { get; set; }
    }
}
