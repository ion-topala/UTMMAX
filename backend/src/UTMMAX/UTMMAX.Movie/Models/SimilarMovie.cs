namespace UTMMAX.Movie.Models;

public class SimilarMovie
{
    public string Id              { get; set; }
    public string Name            { get; set; }
    public string EnName          { get; set; }
    public string AlternativeName { get; set; }
    public Poster Poster          { get; set; }
}