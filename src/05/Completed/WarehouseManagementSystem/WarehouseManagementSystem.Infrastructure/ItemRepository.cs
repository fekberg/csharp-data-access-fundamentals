namespace WarehouseManagementSystem.Infrastructure;

public class ItemRepository : GenericRepository<Item>
{
    public ItemRepository(WarehouseContext context) 
        : base(context)
    {
    }

    public override Item Update(Item entity)
    {
        Item toUpdate = Get(entity.Id);
        toUpdate.Price = entity.Price;
        toUpdate.Name = entity.Name;

        return base.Update(toUpdate);
    }
}
