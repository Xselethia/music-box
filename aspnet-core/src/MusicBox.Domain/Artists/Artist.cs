using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace MusicBox.Artists;

public class Artist : AggregateRoot<Guid>
{
    private readonly List<Album> _albums = new();
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string Image { get; private set; }
    public string Biography { get; private set; }
    public IReadOnlyCollection<Album> Albums => _albums;

    private Artist()
    {
    }

    public Artist(Guid id, string name, string lastName = null, string image = null, string biography = null)
        : base(id)
    {
        Name = Check.NotNullOrEmpty(name, nameof(name), MusicBoxConstants.Artist.NameMaxLength);
        LastName = Check.Length(lastName, nameof(lastName), MusicBoxConstants.Artist.LastNameMaxLength);
        Image = Check.Length(image, nameof(image), MusicBoxConstants.Artist.ImageMaxLength);
        Biography = Check.Length(biography, nameof(biography), MusicBoxConstants.Artist.BiographyMaxLength);
    }

    public Album AddAlbum(Guid albumId, [NotNull] string albumName, int releaseDate, bool isSingle,
        string coverImage = null)
    {
        var album = new Album(albumId, albumName, releaseDate, isSingle, coverImage);
        _albums.AddIfNotContains(album);
        return album;
    }

    public Album AddSongToAlbum(Guid albumId,
        Guid songId,
        [NotNull] string name,
        [NotNull] string sourceLink,
        [NotNull] string genre,
        SongMetaData metadata,
        string lyrics = null)
    {
        var album = _albums.Find(q => q.Id == albumId);
        if (album == null)
        {
            throw new BusinessException("ArtistError001", "Album not found!");
        }

        album.AddSong(songId, name, sourceLink, genre, metadata, lyrics);
        return album;
    }

    public Album AddSingleSong(Guid songId,
        int releaseDate,
        [NotNull] string name,
        [NotNull] string sourceLink,
        [NotNull] string genre,
        SongMetaData metadata,
        string lyrics = null,
        string coverImage = null)
    {
        var newAlbum = new Album(songId, name, releaseDate, true, coverImage);
        newAlbum.AddSong(songId, name, sourceLink, genre, metadata, lyrics);
        _albums.AddIfNotContains(newAlbum);
        return newAlbum;
    }
}