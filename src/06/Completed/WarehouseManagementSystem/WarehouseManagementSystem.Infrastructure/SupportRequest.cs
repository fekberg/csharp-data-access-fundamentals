using Azure;
using Azure.Data.Tables;

namespace WarehouseManagementSystem.Infrastructure;

public class SupportRequest : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    public string Email { get; set; }
    public string Message { get; set; }
}