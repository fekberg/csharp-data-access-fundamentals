using Microsoft.Azure.Cosmos;

namespace WarehouseManagementSystem.Infrastructure;

public class InvoiceRepository
{
    public async Task Add(Invoice invoice)
    {
        using var client = new CosmosClient(
            accountEndpoint: "ADD THE ENDPOINT HERE",
            authKeyOrResourceToken: "ADD THE TOKEN HERE"
        );

        Database database =
            await client.CreateDatabaseIfNotExistsAsync("WarehouseManagementSystem");

        Container container =
            await database.CreateContainerIfNotExistsAsync(
                id: "invoices",
                partitionKeyPath: "/customerId",
                throughput: 400
            );

        await container.UpsertItemAsync(invoice);
    }
}
