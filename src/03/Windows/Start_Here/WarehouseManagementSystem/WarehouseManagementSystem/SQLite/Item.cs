using System;
using System.Collections.Generic;

namespace Warehouse.Data.SQLite
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
        public string Price { get; set; } = null!;
        public long InStock { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }

        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
