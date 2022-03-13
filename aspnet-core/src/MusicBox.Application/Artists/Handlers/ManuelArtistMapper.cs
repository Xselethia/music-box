using System.Collections.Generic;
using System.Linq;
using MusicBox.Albums;
using MusicBox.Artists.Querries.Dtos;
using MusicBox.Songs;
using Volo.Abp.DependencyInjection;

namespace MusicBox.Artists.Handlers;

public class ManuelArtistMapper : ISingletonDependency
{
    public ArtistDto MapToArtistDto(Artist entity)
    {
        return new ArtistDto()
        {
            Id = entity.Id,
            Biography = entity.Biography,
            Image = entity.Image,
            Name = entity.Name,
            LastName = entity.LastName
        };
    }

    public ArtistDetailedDto MapToArtistDetailedDto(Artist entity)
    {
        return new ArtistDetailedDto()
        {
            Id = entity.Id,
            Image = entity.Image,
            Name = entity.Name,
            LastName = entity.LastName,
            Biography = entity.Biography,
            Albums = MapToAlbumDetailedDtos(entity.Albums.ToList())
        };
    }

    public List<AlbumDetailedDto> MapToAlbumDetailedDtos(List<Album> entities)
    {
        List<AlbumDetailedDto> albumDtos = new List<AlbumDetailedDto>();
        foreach (var entity in entities)
        {
            albumDtos.Add(MapToAlbumDetailedDto(entity));
        }

        return albumDtos;
    }

    public AlbumDetailedDto MapToAlbumDetailedDto(Album entity)
    {
        return new AlbumDetailedDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            CoverImage = entity.CoverImage,
            IsSingle = entity.IsSingle,
            ReleaseYear = entity.ReleaseYear,
            Songs = MapToSongDtos(entity.Songs.ToList())
        };
    }

    public List<SongDto> MapToSongDtos(List<Song> entities)
    {
        List<SongDto> songDtos = new List<SongDto>();
        foreach (var entity in entities)
        {
            songDtos.Add(MapToSongDto(entity));
        }

        return songDtos;
    }

    public SongDto MapToSongDto(Song entity)
    {
        return new SongDto()
        {
            Id = entity.Id,
            Genre = entity.Genre,
            Lyrics = entity.Lyrics,
            Name = entity.Name,
            SourceLink = entity.SourceLink,
            Suffix = entity.MetaData.Suffix,
            LengthInSeconds = entity.MetaData.LengthInSeconds
        };
    }
}