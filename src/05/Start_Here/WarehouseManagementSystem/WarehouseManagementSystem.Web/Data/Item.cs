using System;
using System.Collections.Generic;

namespace WarehouseManagementSystem
{
    public partial class Item
    {
        public Item()
        {
            LineItems = new HashSet<LineItem>();
            Warehouses = new HashSet<Warehouse>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int InStock { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }

        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
