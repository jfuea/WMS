using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Application.ProductLists.Queries.GetProducts
{
    public class ProductsVm
    {
        public IList<ProductListDto> Lists { get; set; }
    }
}
