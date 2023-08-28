using System;
using Newtonsoft.Json;

namespace RentalListingsApp.Shared.Models {
public class Listing
{
    [JsonProperty("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("price")]
    public double Price { get; set; }

    [JsonProperty("area")]
    public double Area { get; set; }

    [JsonProperty("mainPhotoUrl")]
    public string MainPhotoUrl { get; set; }

    [JsonProperty("additionalPhotosUrls")]
    public string[] AdditionalPhotosUrls { get; set; }

    [JsonProperty("isSavedForLater")]
    public bool IsSavedForLater { get; set; }
    }
}