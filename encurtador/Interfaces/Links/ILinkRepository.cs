namespace encurtador.Interfaces.Links;

public interface ILinkRepository
{
    public Task CreateLinkAsync(string originalUrl, string shortenedUrl);
    public Task<Models.Links?> GetLinkByShortenedUrlAsync(string shortenedUrl);
    public Task IncrementClickCountAsync(string shortenedUrl);
}