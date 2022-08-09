using Microsoft.AspNetCore.Mvc;
using WarehouseManagementSystem.Infrastructure;

namespace WarehouseManagementSystem.Web.Controllers;

public class CustomerController : Controller
{
    private IRepository<Customer> customerRepository;

    public CustomerController(IRepository<Customer> customerRepository)
    {
        this.customerRepository = customerRepository;
    }

    public IActionResult Index(Guid? id)
    {
        if (id == null)
        {
            var customers = customerRepository.All();

            return View(customers);
        }
        else
        {
            var customer = customerRepository.Get(id.Value);

            return View(new[] { customer });
        }
    }
}
