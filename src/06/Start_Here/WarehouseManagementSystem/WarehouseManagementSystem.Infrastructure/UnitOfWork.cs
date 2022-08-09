namespace WarehouseManagementSystem.Infrastructure;

public interface IUnitOfWork
{
    IRepository<Customer> CustomerRepository { get;  }
    IRepository<Order> OrderRepository { get; }
    IRepository<Item> ItemRepository { get; }
    IRepository<ShippingProvider> ShippingProviderRepository { get; }

    void SaveChanges();
}

public class UnitOfWork : IUnitOfWork
{
    private WarehouseContext context;

    public UnitOfWork(WarehouseContext context)
    {
        this.context = context;
    }

    private IRepository<Customer> customerRepository;
    public IRepository<Customer> CustomerRepository
    {
        get
        {
            if (customerRepository is null)
            {
                customerRepository =
                    new CustomerRepository(context);
            }
            return customerRepository;
        }
    }

    private IRepository<Order> orderRepository;
    public IRepository<Order> OrderRepository
    {
        get
        {
            if (orderRepository is null)
            {
                orderRepository =
                    new OrderRepository(context);
            }
            return orderRepository;
        }
    }

    private IRepository<Item> itemRepository;
    public IRepository<Item> ItemRepository
    {
        get
        {
            if (itemRepository is null)
            {
                itemRepository =
                    new ItemRepository(context);
            }
            return itemRepository;
        }
    }

    public IRepository<ShippingProvider>
        shippingProviderRepository;

    public IRepository<ShippingProvider>
        ShippingProviderRepository
    {
        get
        {
            if (shippingProviderRepository is null)
            {
                shippingProviderRepository
                    = new ShippingProviderRepository(context);
            }

            return shippingProviderRepository;
        }
    }

    public void SaveChanges() => context.SaveChanges();
}
