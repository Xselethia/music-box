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
//         var sql = @"
//             CREATE OR ALTER VIEW [dbo].[View_SongDetails] AS
// SELECT        Songs.Id, Songs.Name, Songs.Lyrics, Songs.Genre, Songs.SourceLink, Songs.Length, Albums.Id AS AlbumId, Albums.Name AS AlbumName, Albums.ReleaseYear AS AlbumReleaseYear, 
//                          Albums.CoverImage AS AlbumCoverImage, Albums.IsSingle AS AlbumIsSingle, Artists.Id AS ArtistId, Artists.Name AS ArtistName, Artists.LastName AS ArtistLastName
// FROM            Albums INNER JOIN
//                          Artists ON Albums.ArtistId = Artists.Id INNER JOIN
//                          Songs ON Albums.Id = Songs.AlbumId";
        var sql = @"
            CREATE VIEW View_SongDetails AS
SELECT        Songs.Id, Songs.Name, Songs.Lyrics, Songs.Genre, Songs.SourceLink, Songs.Length, Albums.Id AS AlbumId, Albums.Name AS AlbumName, Albums.ReleaseYear AS AlbumReleaseYear, 
                         Albums.CoverImage AS AlbumCoverImage, Albums.IsSingle AS AlbumIsSingle, Artists.Id AS ArtistId, Artists.Name AS ArtistName, Artists.LastName AS ArtistLastName
FROM            Albums INNER JOIN
                         Artists ON Albums.ArtistId = Artists.Id INNER JOIN
                         Songs ON Albums.Id = Songs.AlbumId";
        //TODO : SqlServer ise "Or ALTER" kullan
        var dbContext = await GetDbContextAsync();
        var provider = dbContext.Database.ProviderName;
        await dbContext.Database.ExecuteSqlRawAsync(sql);
    }
}