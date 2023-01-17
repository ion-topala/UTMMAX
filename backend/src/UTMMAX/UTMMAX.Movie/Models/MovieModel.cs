namespace UTMMAX.Movie.Models;

public class MovieModel
{
    public int?       Id               { get; set; }
    public string?    Type             { get; set; }
    public string?    Description      { get; set; }
    public int?       Year             { get; set; }
    public string?    AlternativeName  { get; set; }
    public string?    EnName           { get; set; }
    public int?       MovieLenght      { get; set; }
    public string?    ShortDescription { get; set; }
    public ExternalId ExternalId       { get; set; }
    public Logo       Logo             { get; set; }
    public Poster     Poster           { get; set; }
    public Rating     Rating           { get; set; }
    public Votes      Votes            { get; set; }
}