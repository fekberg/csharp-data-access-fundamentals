namespace WarehouseManagementSystem.Domain
{
    public class LineItem
    {
        public Guid Id { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}