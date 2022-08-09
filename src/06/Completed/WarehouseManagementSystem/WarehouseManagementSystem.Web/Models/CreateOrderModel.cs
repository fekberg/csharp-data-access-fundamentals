namespace WarehouseManagementSystem.Web.Models;

public class CreateOrderModel
{
    public IEnumerable<LineItemModel> LineItems { get; set; }

    public CustomerModel Customer { get; set; }
}
