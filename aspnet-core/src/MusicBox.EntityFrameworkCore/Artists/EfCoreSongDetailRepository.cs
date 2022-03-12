using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicBox.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MusicBox.Artists;

public class EfCoreSongDetailRepository : EfCoreRepository<MusicBoxDbContext, SongDetail, Guid>, ISongDetailRepository
{
    public EfCoreSongDetailRepository(IDbContextProvider<MusicBoxDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task CreateViewAsync()
    {
        string sqlQuery;

        var dbContext = await GetDbContextAsync();
        if (dbContext.Database.ProviderName != null && dbContext.Database.ProviderName.EndsWith("Sqlite"))
        {
            sqlQuery = @"CREATE VIEW ";
        }
        else
        {
            sqlQuery = @"CREATE OR ALTER VIEW ";

        }
        sqlQuery += @"View_SongDetails AS SELECT Songs.Id, Songs.Name, Songs.Lyrics, Songs.Genre, Songs.SourceLink, Songs.Length, Albums.Id AS AlbumId, Albums.Name AS AlbumName, Albums.ReleaseYear AS AlbumReleaseYear, 
                Albums.CoverImage AS AlbumCoverImage, Albums.IsSingle AS AlbumIsSingle, Artists.Id AS ArtistId, Artists.Name AS ArtistName, Artists.LastName AS ArtistLastName
                FROM Albums INNER JOIN
                Artists ON Albums.ArtistId = Artists.Id INNER JOIN
            Songs ON Albums.Id = Songs.AlbumId";

        await dbContext.Database.ExecuteSqlRawAsync(sqlQuery);
    }
}