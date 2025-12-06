using System.Security.Cryptography;
using encurtador.DTOs.Links;
using encurtador.Interfaces.Links;
using encurtador.Repositories;

namespace encurtador.Services.Links;

public class LinksService(ILinkRepository repo) : ILinkService
{
    private const int ShortenedUrlLength = 6;
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public async Task<string> CreateShortenedLinkAsync(CreateShortenerLinkDto dto)
    {
       var shortenedUrl = GenerateShortCode(ShortenedUrlLength);
       bool exists = await repo.GetLinkByShortenedUrlAsync(shortenedUrl) != null;
       while (exists)
       {
           shortenedUrl = GenerateShortCode(ShortenedUrlLength);
           exists = await repo.GetLinkByShortenedUrlAsync(shortenedUrl) != null;
       }
       await repo.CreateLinkAsync(dto.Url, shortenedUrl);
       return shortenedUrl;
       
    }

    public async Task<string?> GetOriginalLinkAsync(string shortenedUrl)
    {
        var link = await repo.GetLinkByShortenedUrlAsync(shortenedUrl);
        if (link == null)
        {
            return null;
        }

        await repo.IncrementClickCountAsync(shortenedUrl);
        return link.OriginalUrl;
    }

    private static string GenerateShortCode(int length)
    {
        var bytes = RandomNumberGenerator.GetBytes(length);
        var chars = new char[length];
        for (int i = 0; i < length; i++)
        {
            chars[i] = Alphabet[bytes[i] % Alphabet.Length];
        }
        return new string(chars);
    }
}