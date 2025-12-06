using encurtador.DTOs.Links;
using encurtador.Interfaces.Links;
using encurtador.Services.Links;

namespace encurtador.Endpoints;

public static class LinksEndpoints 

{
    public static void MapLinksEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/links/shorten", async (HttpContext ctx, CreateShortenerLinkDto dto, ILinkService linkService) =>
        {
            var code = await linkService.CreateShortenedLinkAsync(dto);

            var baseUrl = $"{ctx.Request.Scheme}://{ctx.Request.Host}/api/links/";
            var shortenedUrl = baseUrl + code;

            return Results.Ok(new { shortenedUrl });
        });
        
        endpoints.MapGet("/api/links/{shortenedUrl}", async (string shortenedUrl, ILinkService linkService) =>
        {
            var originalUrl = await linkService.GetOriginalLinkAsync(shortenedUrl);
            if (originalUrl == null)
            {
                return Results.NotFound();
            }
            return Results.Redirect(originalUrl);
        });
    }

   
}