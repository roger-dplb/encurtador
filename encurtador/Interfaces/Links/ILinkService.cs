using encurtador.DTOs.Links;

namespace encurtador.Interfaces.Links;

public interface ILinkService
{
    public Task<string> CreateShortenedLinkAsync(CreateShortenerLinkDto dto);
    public Task<string?> GetOriginalLinkAsync(string shortenedUrl);
}