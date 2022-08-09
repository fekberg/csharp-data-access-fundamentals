namespace WarehouseManagementSystem.Infrastructure;

public class CustomerRepository
    : GenericRepository<Customer>
{
    public CustomerRepository(WarehouseContext context) 
        : base(context)
    {
    }

    public override Customer Update(Customer entity)
    {
        Customer toUpdate = Get(entity.Id);
        toUpdate.Name = entity.Name;
        toUpdate.Address = entity.Address;
        toUpdate.PostalCode = entity.PostalCode;
        toUpdate.Country = entity.Country;
        toUpdate.PhoneNumber = entity.PhoneNumber;

        return base.Update(toUpdate);
    }
}
