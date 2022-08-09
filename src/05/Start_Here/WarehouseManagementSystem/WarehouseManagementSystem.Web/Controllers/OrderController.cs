using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Web.Models;

namespace WarehouseManagementSystem.Web.Controllers;

public class OrderController : Controller
{
    private WarehouseContext context;

    public OrderController()
    {
        context = new WarehouseContext();
    }

    public IActionResult Index()
    {
        var orders = context.Orders
            .Include(order => order.LineItems)
            .ThenInclude(lineItem => lineItem.Item)
            .Where(order => 
            order.CreatedAt > DateTime.UtcNow.AddDays(-1)
        ).ToList();

        return View(orders);
    }

    public IActionResult Create()
    {
        var items = context.Items.ToList();

        return View(items);
    }

    [HttpPost]
    public IActionResult Create(CreateOrderModel model)
    {
        #region Validate input
        if (!model.LineItems.Any()) return BadRequest("Please submit line items");

        if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");
        #endregion

        var customer = new Customer
        {
            Name = model.Customer.Name,
            Address = model.Customer.Address,
            PostalCode = model.Customer.PostalCode,
            Country = model.Customer.Country,
            PhoneNumber = model.Customer.PhoneNumber
        };

        var order = new Order
        {
            LineItems = model.LineItems
                .Select(line => new LineItem { 
                    Id = Guid.NewGuid(), 
                    ItemId = line.ItemId, 
                    Quantity = line.Quantity
                })
                .ToList(),

            Customer = customer,
            ShippingProvider = context.ShippingProviders.First(),
            CreatedAt = DateTimeOffset.UtcNow
        };

        context.Orders.Add(order);

        context.SaveChanges();

        return Ok("Order Created");
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
