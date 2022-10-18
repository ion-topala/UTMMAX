using UTMMAX.Kinopoisk.Models;

namespace UTMMAX.Kinopoisk;

public interface IKinopoiskService
{
    Task<QueryResponseModel> SearchAsync(string searchTerm);
}