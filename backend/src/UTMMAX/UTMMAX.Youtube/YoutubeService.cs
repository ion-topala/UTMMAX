using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UTMMAX.Service;

namespace UTMMAX.Youtube;

public class YoutubeService : IYoutubeService
{
    private readonly HttpClient              _httpClient;
    private readonly IOptions<YoutubeConfig> _options;
    private readonly ILogger<YoutubeService> _logger;

    private const string SearchUrl = "https://www.googleapis.com/youtube/v3/search";

    public YoutubeService(
        HttpClient              httpClient,
        IOptions<YoutubeConfig> options,
        ILogger<YoutubeService> logger)
    {
        _httpClient = httpClient;
        _options    = options;
        _logger     = logger;
    }

    public async Task<int> SearchTrailerVideo(string movieName)
    {
        _logger.LogInformation("Calling youtube api");

        try
        {
            using var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
            {
                new("part", "snippet"),
                new("q", $"trailer-{movieName}"),
                new("topicId", "%2Fm%2F02vxn"),
                new("key", _options.Value.ApiKey),
            });

            var query = content.ReadAsStringAsync().Result;

            var response = await _httpClient
                .GetAsync($"{SearchUrl}?{query}");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            
            //todo serialize response

            return default;
        }
        catch (Exception)
        {
            _logger.LogError("Failed to search trailer");
            throw;
        }
    }
}