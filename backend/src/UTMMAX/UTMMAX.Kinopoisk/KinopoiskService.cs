using Newtonsoft.Json;
using UTMMAX.Kinopoisk.Models;

namespace UTMMAX.Kinopoisk;

public class KinopoiskService : IKinopoiskService
{
    private readonly KinopoiskConfig _kinopoiskConfig;
    private readonly HttpClient      _httpClient;

    public KinopoiskService(KinopoiskConfig kinopoiskConfig, HttpClient httpClient)
    {
        _kinopoiskConfig = kinopoiskConfig;
        _httpClient      = httpClient;
    }

    public async Task<QueryResponseModel> SearchAsync(FilterModel filter)
    {
        using var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
        {
            new("token", _kinopoiskConfig.ApiToken),
            new("search", filter.SearchTerm),
            new("field", "alternativeName"),
            new("isStrict", false.ToString().ToLower()),
            new("limit", "100"),
        });
        var query = content.ReadAsStringAsync().Result;

        var result = await CallApi(query);
        result.Docs = result.Docs.Where(model => model.Rating.Imdb > 0.0).ToArray();

        return result;
    }

    public async Task<QueryResponseModel> GetTopByType(FilterModel filter)
    {
        using var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
        {
            new("token", _kinopoiskConfig.ApiToken),
            new("field", "rating.kp"),
            new("search", "8-10"),
            new("field", "year"),
            new("search", "2018-2022"),
            new("field", "typeNumber"),
            new("search", filter.Type.ToString("D")),
            new("sortField", "year"),
            new("sortType", "1"),
            new("sortField", "votes.imdb"),
            new("sortType", "-1"),
            new("limit", filter.Limit.ToString()),
        });
        var query  = content.ReadAsStringAsync().Result;
        var result = await CallApi(query);

        return result;
    }

    private async Task<QueryResponseModel> CallApi(string query)
    {
        var response = await _httpClient
            .GetAsync($"{_kinopoiskConfig.ApiUrl}{ApiUrlConstants.MovieUrl}?{query}");
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var result       = JsonConvert.DeserializeObject<QueryResponseModel>(responseBody);

        return result;
    }
}