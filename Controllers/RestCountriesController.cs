using Microsoft.AspNetCore.Mvc;
using UseCase1.Extensions;
using UseCase1.GenericHttpClient;
using UseCase1.Models;

namespace UseCase1.Controllers;

[ApiController]
[Route("[controller]")]
public class RestCountriesController : ControllerBase
{
    private readonly Client _client;
    private readonly string _url;

    public RestCountriesController(IConfiguration config, Client client)
    {
        _url = config["Url"];
        _client = client;
    }

    [HttpGet("all")]
    public async Task<List<Country>?> GetAllCountriesParsed(string? nameFilter, int? maxPopulationInMilions, string? sortOrder)
    {
        var result = await _client.Get<List<Country>>(_url + "all");

        if (result == null) return null;

        if (!string.IsNullOrWhiteSpace(nameFilter))
        {
            result = result.FilterByCommonName(nameFilter);
        }

        if (maxPopulationInMilions is not null)
        {
            result = result.FilterByPopulation((int)maxPopulationInMilions);
        }

        if (!string.IsNullOrWhiteSpace(sortOrder))
        {
            result = result.SortByCommonName(sortOrder);
        }

        return result.Paginate(10);
    }
}
