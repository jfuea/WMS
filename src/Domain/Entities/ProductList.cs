using WMS.Domain.Common;
using System.Collections.Generic;

namespace WMS.Domain.Entities
{
    public class ProductList : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IList<ProductItem> Items { get; private set; } = new List<ProductItem>();
    }
}
