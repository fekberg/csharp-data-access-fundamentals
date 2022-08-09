using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem;

Customer filip = new()
{
    Id = Guid.NewGuid(),
    Name = "Filip Ekberg",
    Address = "Kungsbacka",
    PostalCode = "434 94",
    Country = "Sweden",
    PhoneNumber = "+46 111 111 111"
};

ShippingProvider shippingProvider = new()
{
    Id = Guid.NewGuid(),
    Name = "Swedish Postal Service",
    FreightCost = 100m
};

Item item = new()
{
    Id = Guid.NewGuid(),
    Name = "Shure SM7b",
    Description = "Microphone",
    InStock = 5,
    Price = 999,
    Warehouses = new WarehouseManagementSystem.Warehouse[] 
    { 
        new () { Id = Guid.NewGuid(), Location = "Sweden" }
    }
};

Order order = new()
{
    Id = Guid.NewGuid(),
    Customer = filip,
    ShippingProvider = shippingProvider,
    LineItems = new LineItem[]
    {
        new()
        {
            Id = Guid.NewGuid(),
            Item = item,
            Quantity = 1
        }
    }
};
order.LineItems.Add(new());
using var context = new WarehouseContext();
context.Database.Migrate();

context.Orders.Add(order);
context.SaveChanges();

//using Microsoft.EntityFrameworkCore;
//using Warehouse.Data.SQLite;
//using WarehouseManagementSystem;
//using Order = Warehouse.Data.SQLite.Order;
//using LineItem = Warehouse.Data.SQLite.LineItem;
//using Customer = Warehouse.Data.SQLite.Customer;
//using Item = Warehouse.Data.SQLite.Item;
//using ShippingProvider = Warehouse.Data.SQLite.ShippingProvider;
//using Warehouse = Warehouse.Data.SQLite.Warehouse;

//using var context = new WarehouseSQLiteContext();

//var firstCustomer = context.Customers.First();
//Order newOrder = new()
//{
//    Id = Guid.NewGuid(),
//    LineItems = new LineItem[]
//    {
//        new()
//        {
//            Id = Guid.NewGuid(),
//            Item = context.Items.First(),
//            Quantity = 1
//        }
//    },
//    ShippingProvider = context.ShippingProviders.First(),
//    Customer = firstCustomer
//};

//context.Orders.Add(newOrder);
//context.SaveChanges();
//Console.WriteLine("Order added!");










//Console.ReadLine();





//Console.Write("Enter customer name: ");

//var newCustomer = new Customer
//{
//    Name = Console.ReadLine(),
//    Address = "Kungsbacka",
//    PostalCode = "434 94",
//    Country = "Sweden",
//    PhoneNumber = "+46 111 111 11"
//};

//context.Customers.Add(newCustomer);

//context.SaveChanges();

//var toUpdate = context.Customers
//    .First(customer => customer.Name == "Filip Ekberg (1)");

//toUpdate.Name = "Sofie Ekberg";

//context.Customers.Update(toUpdate);

//context.SaveChanges();

//Console.ReadLine();






//var customer = context.Customers
//    .FirstOrDefault(customer => customer.Name == "Filip Ekberg");

//foreach(var order in 
//    context.Orders
//    .Where(order => order.CustomerId == customer.Id)
//    .Include(order => order.Customer)
//    .Include(order => order.ShippingProvider)
//    .Include(order => order.LineItems)
//    .ThenInclude(lineItem => lineItem.Item))
//{
//    Console.WriteLine($"Order Id: {order.Id}");
//    Console.WriteLine($"Customer: {order.Customer.Name}");
//    Console.WriteLine($"Shipping Provider: {order.ShippingProvider.Name}");
//    foreach (var lineItem in order.LineItems)
//    {
//        Console.WriteLine($"\t{lineItem.Item.Name}");
//        Console.WriteLine($"\t{lineItem.Item.Price}");
//    }
//}

//Console.ReadLine();