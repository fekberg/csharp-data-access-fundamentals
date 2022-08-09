using System.Text.Json;
using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem
{
    internal class LocalData
    {
        public static IEnumerable<Order> Load()
        {
            var json = File.ReadAllText("orders.json");

            return JsonSerializer.Deserialize<IEnumerable<Order>>(json) ?? Enumerable.Empty<Order>();
        }

        public static void GenerateAndSave()
        {
            var warehouses = new Warehouse[]
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Location = "Sweden"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Location = "USA"
                }
                        };

            var items = new Item[]
            {
                new() { Id = Guid.NewGuid(), Name = "Shure SM7b", InStock = 5,  Price = 399.50m, Description = "Popular microphone for streaming, podcasting and voice over", Warehouses = warehouses},
                new() { Id = Guid.NewGuid(), Name = "Sennheiser MKH 416", InStock = 3,  Price = 1099.50m, Description = "Professional voice over microphone", Warehouses = warehouses}
                        };

            var shippingProviders = new ShippingProvider[]
            {
                new() { Id = Guid.NewGuid(), Name = "Swedish Postal Service", FreightCost = 10m },
                new() { Id = Guid.NewGuid(), Name = "United States Postal Service", FreightCost = 5m }
                        };

            var customer = new Customer()
            {
                Id = Guid.NewGuid(),
                Name = "Filip Ekberg",
                Address = "Vallda",
                Country = "Sweden",
                PhoneNumber = "+46 555 123 123",
                PostalCode = "434 94"
            };

            var orders = new Order[]
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Customer = customer,
                    LineItems = new LineItem[]
                    {
                        new() { Id = Guid.NewGuid(), Item = items[0], Quantity = 2 },
                        new() { Id = Guid.NewGuid(), Item = items[1], Quantity = 1 }
                    },
                    ShippingProvider = shippingProviders.First()
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Customer = customer,
                    LineItems = new LineItem[]
                    {
                        new() { Id = Guid.NewGuid(), Item = items[0], Quantity = 4 }
                    },
                    ShippingProvider = shippingProviders[1]
                },
            };

            var json = JsonSerializer.Serialize(orders);

            File.WriteAllText("orders.json", json);
        }
    }
}
