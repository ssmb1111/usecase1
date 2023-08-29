using Microsoft.AspNetCore.Mvc;
using UseCase1.GenericHttpClient;
using UseCase1.Models;

namespace UseCase1.Controllers;

[ApiController]
[Route("[controller]")]
public class RestCountriesController : ControllerBase
{
    private readonly ILogger<RestCountriesController> _logger;
    private readonly Client _client;


    public RestCountriesController(ILogger<RestCountriesController> logger, Client client)
    {
        _logger = logger;
        _client = client;
    }

    [HttpGet("all")]
    public async Task<List<Country>?> GetAllCountriesParsed(string? str1, int? number, string? str2)
    {
        var result = await _client.Get<List<Country>>("https://restcountries.com/v3.1/all");

        return result;
    }
}
