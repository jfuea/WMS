using WMS.Domain.Common;
using WMS.Domain.Enums;
using WMS.Domain.Events;
using System;
using System.Collections.Generic;

namespace WMS.Domain.Entities
{
    public class ProductCategory : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        // TODO ParentCategory

        // TODO Logistics/Force Removal Strategy
    }
}
