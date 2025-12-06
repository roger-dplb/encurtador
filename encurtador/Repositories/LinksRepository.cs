using encurtador.Infra;
using encurtador.Interfaces.Links;
using encurtador.Models;
using Microsoft.EntityFrameworkCore;

namespace encurtador.Repositories;

public class LinksRepository(ApplicationDbContext dbContext) : ILinkRepository
{
    public async Task CreateLinkAsync(string originalUrl, string shortenedUrl)
    {
        var newLink = new Links
        {
            OriginalUrl = originalUrl,
            ShortenedUrl = shortenedUrl,
            ClickCount = 0,
            CreatedAt = DateTime.UtcNow
        };
        await dbContext.Links.AddAsync(newLink);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Links?> GetLinkByShortenedUrlAsync(string shortenedUrl)
    {
        return await dbContext.Links
            .FirstOrDefaultAsync(link => link.ShortenedUrl == shortenedUrl);
    }

    public async Task IncrementClickCountAsync(string shortenedUrl)
    {
       var link = await GetLinkByShortenedUrlAsync(shortenedUrl);
         if (link != null)
         {
              link.ClickCount += 1;
              await dbContext.SaveChangesAsync();
         }
    }
}