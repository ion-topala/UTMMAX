﻿namespace UTMMAX.Movie.Models;

public class Votes : BaseMovieModel
{
    public int Kp                 { get; set; }
    public int Imdb               { get; set; }
    public int FilmCritics        { get; set; }
    public int RussianFilmCritics { get; set; }
    public int Await              { get; set; }
}