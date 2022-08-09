using System;
using System.Collections.Generic;

namespace Warehouse.Data.SQLite
{
    public partial class Order
    {
        public Order()
        {
            LineItems = new HashSet<LineItem>();
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; } 
        public Guid ShippingProviderId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ShippingProvider ShippingProvider { get; set; } = null!;
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
