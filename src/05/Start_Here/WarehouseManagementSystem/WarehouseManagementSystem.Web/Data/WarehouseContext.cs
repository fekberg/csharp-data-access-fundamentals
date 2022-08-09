using Microsoft.EntityFrameworkCore;

namespace WarehouseManagementSystem
{
    public class WarehouseContext
        : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShippingProvider> ShippingProviders { get; set; }

        protected override void 
            OnConfiguring(DbContextOptionsBuilder 
            optionsBuilder)
        {
            // MOVE TO A SECURE PLACE!!!!
            var connectionString =
                "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "Initial Catalog=WarehouseManagement;" +
                "Integrated Security=True;";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
