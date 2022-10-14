namespace UTMMAX.Kinopoisk.Models;

public class ResultModel
{
    public MovieModel[] Docs  { get; set; }
    public int          Total { get; set; }
    public int          Limit { get; set; }
    public int          Page  { get; set; }
    public int          Pages { get; set; }
}