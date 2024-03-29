﻿using UTMMAX.Movie.Models;

namespace UTMMAX.Kinopoisk;

public interface IKinopoiskService
{
    Task<QueryResponseModel> SearchAsync(FilterModel  filter);
    Task<QueryResponseModel> GetTopByType(FilterModel filter);
    Task<MovieDetailsModel>  GetById(double           id);
}