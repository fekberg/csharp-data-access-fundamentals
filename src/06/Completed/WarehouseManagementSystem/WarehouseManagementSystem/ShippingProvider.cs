using System;
using System.Collections.Generic;

namespace WarehouseManagementSystem
{
    public partial class ShippingProvider
    {
        public ShippingProvider()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal FreightCost { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
