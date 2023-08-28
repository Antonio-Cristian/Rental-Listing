// src/Backend/RentalListingsAPI/Services/CosmosDbService.cs
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using RentalListingsAPI.Models;

public class CosmosDbService 
{
    private readonly CosmosClient _cosmosClient;
    private readonly Container _container;

    public CosmosDbService()
    {
        string connectionString = "AccountEndpoint=https://db-account-antonio.documents.azure.com:443/;AccountKey=s95aQPmp6EYpq11V0W1TwOTZStqMZqN9IW6LuJEGhDrJ3QiQLd42ZG1ohEub3aK9wQIzt0jZdlHmACDbMGxkuA==;";
        _cosmosClient = new CosmosClient(connectionString);
        _container = _cosmosClient.GetContainer("RentalListingsDB", "Listings");
    }

     public async Task AddListingAsync(Listing listing)
    {
        await _container.CreateItemAsync(listing);
    }

    public async Task<IEnumerable<Listing>> GetAllListingsAsync()
    {
        var query = _container.GetItemLinqQueryable<Listing>().ToFeedIterator();
        List<Listing> results = new List<Listing>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response.ToList());
        }
        return results;
    }

public async Task<Listing> GetListingByIdAsync(string id)
{
    ItemResponse<Listing> response = await _container.ReadItemAsync<Listing>(id, new PartitionKey(id));
    return response.Resource;
}

    public async Task DeleteListingAsync(string id)
{
    await _container.DeleteItemAsync<Listing>(id, new PartitionKey(id));
}

public async Task UpdateListingAsync(string id, Listing listing)
{
    await _container.UpsertItemAsync(listing, new PartitionKey(id));
}


    // Add more CRUD methods as needed
}

