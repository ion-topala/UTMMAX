using UTMMAX.Kinopoisk.Enums;

namespace UTMMAX.Movie.Models;

public class MovieDetailsModel
{
    public int                     Id                  { get; set; }
    public Logo                    Logo                { get; set; }
    public Poster                  Poster              { get; set; }
    public Rating                  Rating              { get; set; }
    public Votes                   Votes               { get; set; }
    public Videos                  Videos              { get; set; }
    public Budget                  Budget              { get; set; }
    public Premiere                Premiere            { get; set; }
    public string                  Status              { get; set; }
    public List<ProductionCompany> ProductionCompanies { get; set; }
    public List<SpokenLanguage>    SpokenLanguages     { get; set; }
    public string                  Type                { get; set; }
    public string                  Name                { get; set; }
    public string                  Description         { get; set; }
    public string                  Slogan              { get; set; }
    public int                     Year                { get; set; }
    public List<Fact>              Facts               { get; set; }
    public List<Genre>             Genres              { get; set; }
    public List<Country>           Countries           { get; set; }
    public List<SeasonsInfo>       SeasonsInfo         { get; set; }
    public List<Person>            Persons             { get; set; }
    public MovieType               TypeNumber          { get; set; }
    public string                  AlternativeName     { get; set; }
    public object                  EnName              { get; set; }
    public List<MovieName>         Names               { get; set; }
    public object                  AgeRating           { get; set; }
    public int                     MovieLength         { get; set; }
    public object                  RatingMpaa          { get; set; }
    public DateTime                UpdatedAt           { get; set; }
    public object                  ShortDescription    { get; set; }
    public Technology              Technology          { get; set; }
    public bool                    TicketsOnSale       { get; set; }
    public List<SequelsAndPrequel> SequelsAndPrequels  { get; set; }
    public List<SimilarMovie>      SimilarMovies       { get; set; }
    public List<ReleaseYear>       ReleaseYears        { get; set; }
    public object                  Top10               { get; set; }
    public object                  Top250              { get; set; }
    public DateTime                CreateDate          { get; set; }
}