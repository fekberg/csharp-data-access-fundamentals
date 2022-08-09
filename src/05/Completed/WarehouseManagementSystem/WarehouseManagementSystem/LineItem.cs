using System;
using System.Collections.Generic;

namespace WarehouseManagementSystem
{
    public partial class LineItem
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }

        public virtual Item Item { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
