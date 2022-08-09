using Microsoft.AspNetCore.Mvc;

namespace WarehouseManagementSystem.Web.Controllers;

public class CustomerController : Controller
{
    private WarehouseContext context;

    public CustomerController()
    {
        context = new WarehouseContext();
    }

    public IActionResult Index(Guid? id)
    {
        if (id == null)
        {
            var customers = context.Customers.ToList();

            return View(customers);
        }
        else
        {
            var customer = context.Customers.Find(id.Value);

            return View(new[] { customer });
        }
    }
}
