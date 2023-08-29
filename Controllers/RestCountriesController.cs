using Microsoft.AspNetCore.Mvc;
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
    public async Task<List<Country>?> GetAllCountriesParsed(string? str1, int? number, string? str2)
    {
        var result = await _client.Get<List<Country>>(_url + "all");

        return result;
    }
}
