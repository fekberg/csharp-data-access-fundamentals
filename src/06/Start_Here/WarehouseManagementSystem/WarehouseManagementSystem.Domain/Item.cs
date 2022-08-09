namespace WarehouseManagementSystem.Domain
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public ICollection<Warehouse> Warehouses { get; set; }
    }
}