namespace WarehouseManagementSystem.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public ShippingProvider ShippingProvider { get; set; }
        public ICollection<LineItem> LineItems { get; set; }
    }
}