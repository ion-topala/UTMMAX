namespace UTMMAX.Kinopoisk;

public class KinopoiskService : IKinopoiskService
{
    private readonly KinopoiskConfig _kinopoiskConfig;
    private readonly HttpClient      _httpClient;

    public KinopoiskService(KinopoiskConfig kinopoiskConfig, HttpClient httpClient)
    {
        _kinopoiskConfig = kinopoiskConfig;
        this._httpClient = httpClient;
    }

    public async Task SearchAsync(string searchTerm)
    {
        string query;
        using var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
        {
            new("token", _kinopoiskConfig.ApiToken),
            new("search", searchTerm),
            new("field", "alternativeName"),
            new("isStrict", false.ToString().ToLower()),
        });
        query = content.ReadAsStringAsync().Result;

        var response = await _httpClient
            .GetAsync($"{_kinopoiskConfig.ApiUrl}{ApiUrlConstants.MovieUrl}{query}");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
    }
}