using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MusicBox.Artists;

public static class EfCoreArtistQueryableExtenstions
{
    public static IQueryable<Artist> IncludeAlbums(this IQueryable<Artist> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            .Include(x => x.Albums);
    }

    public static IQueryable<Artist> IncludeSongs(this IQueryable<Artist> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            .Include(x => x.Albums)
            .ThenInclude(q => q.Songs);
    }
}