using WMS.Domain.Common;
using WMS.Domain.Enums;
using WMS.Domain.Events;
using System;
using System.Collections.Generic;

namespace WMS.Domain.Entities
{
    public class ProductItem : AuditableEntity
    {
        public int Id { get; set; }

        public ProductList List { get; set; }

        public int ListId { get; set; }

        // 1. General Information

        public string Name { get; set; }

        //public bool CanBeSold { get; set; }

        //public bool CanBePurchased { get; set; }

        public ProductType Type { get; set; }

        public string Note { get; set; }

        public decimal SalesPrice { get; set; }

        public decimal Cost { get; set; }

        //public ProductCategory Category { get; set; }

        public string InternalReference { get; set; }

        public string Barcode { get; set; }

        //public string Notes { get; set; }

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
}
