using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentalListingsAPI.Models;

[ApiController]
[Route("[controller]")]
public class ListingsController : ControllerBase
{
    private readonly CosmosDbService _cosmosDbService;

    public ListingsController(CosmosDbService cosmosDbService)
    {
        _cosmosDbService = cosmosDbService;
    }

    [HttpGet]
    public async Task<IEnumerable<Listing>> GetAllListings()
    {
        return await _cosmosDbService.GetAllListingsAsync();
    }

    [HttpGet("{id}")]
    public async Task<Listing> GetListingById(string id)
    {
        Console.WriteLine($"GetListingById called with ID: {id}");
        return await _cosmosDbService.GetListingByIdAsync(id);
    }

    [HttpPost]
    public async Task AddListing([FromBody] Listing listing)
    {
        await _cosmosDbService.AddListingAsync(listing);
    }

    [HttpPut("{id}")]
    public async Task UpdateListing(string id, [FromBody] Listing listing)
    {
        await _cosmosDbService.UpdateListingAsync(id, listing);
    }

    [HttpDelete("{id}")]
    public async Task DeleteListing(string id)
    {
        await _cosmosDbService.DeleteListingAsync(id);
    }
}
