using Azure.Data.Tables;

namespace WarehouseManagementSystem.Infrastructure;

public class SupportRequestRepository
{
    private readonly TableServiceClient tableServiceClient
        = new("CONNECTION STRING");

    private TableClient tableClient;

    public void Initialize()
    {
        tableClient =
            tableServiceClient.GetTableClient("SupportRequests");

        tableClient.CreateIfNotExists();
    }

    public void Add(Guid customerId,
        string email, string message)
    {
        SupportRequest request = new()
        {
            PartitionKey = customerId.ToString(),
            RowKey = Guid.NewGuid().ToString(),
            Email = email,
            Message = message
        };
        tableClient.AddEntity(request);
    }

    public IEnumerable<SupportRequest>
        Get(Guid customerId)
    {
        var requests =
            tableClient.Query<SupportRequest>(
                r => r.PartitionKey == customerId.ToString()
            );

        return requests.ToList();
    }
}
