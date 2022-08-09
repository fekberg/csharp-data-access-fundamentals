using StackExchange.Redis;

namespace WarehouseManagementSystem.Infrastructure;

public class ItemDetailService
{
    private static ConnectionMultiplexer connection;
    private IDatabase database;
    public ItemDetailService()
    {
        connection =
            ConnectionMultiplexer.Connect("CONNECTION STRING");

        database = connection.GetDatabase();
    }

    public string GetDetailsFor(string itemId)
    {
        var details = database.StringGet(itemId);

        if (details.HasValue)
        {
            return details;
        }
        var loadedDetails =
            $"Item details {DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";

        database.StringSet(itemId, loadedDetails);
        return loadedDetails;
    }
}
