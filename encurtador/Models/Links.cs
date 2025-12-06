namespace encurtador.Models;

public class Links
{
    public int Id { get; set; }
    public string OriginalUrl { get; set; }
    public string ShortenedUrl { get; set; }
    public int ClickCount { get; set; }
    public DateTime CreatedAt { get; set; }
    
}