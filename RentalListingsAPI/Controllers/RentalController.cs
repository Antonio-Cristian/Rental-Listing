// src/Backend/RentalListingsAPI/Controllers/RentalController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RentalController : ControllerBase
{
    [HttpGet]
    public ActionResult GetListings()
    {
        // Fetch listings from database
        return Ok();
    }
    
    [HttpPost("refresh")]
    public ActionResult RefreshListings()
    {
        // Refresh listings
        return Ok();
    }
}
