using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace MusicBox.Artists;

public class Album : Entity<Guid>
{
    private readonly List<Song> _songs = new();
    public string Name { get; init; }
    public int ReleaseYear { get; init; }
    public string CoverImage { get; private set; }
    public bool IsSingle { get; init; }

    public IReadOnlyCollection<Song> Songs => _songs;

    private Album()
    {
    }

    public Album(Guid id, [NotNull] string name, int releaseYear, bool isSingle, string coverImage = "")
        : base(id)
    {
        Name = Check.NotNullOrEmpty(name, nameof(name), MusicBoxConstants.Album.NameMaxLength);
        ReleaseYear = releaseYear; // TODO Validate
        IsSingle = isSingle;
        CoverImage = Check.Length(coverImage, nameof(coverImage), MusicBoxConstants.Album.CoverImageMaxLength);
    }

    public void AddSong(Guid songId,
        [NotNull] string name,
        [NotNull] string sourceLink,
        [NotNull] string genre,
        SongMetaData metadata,
        string lyrics = null)
    {
        if (_songs.Count == 1 && IsSingle)
        {
            throw new BusinessException("SongErrorCode001", "You can not add an other song to a single album");
        }

        _songs.AddIfNotContains(new Song(songId, name, sourceLink, genre, metadata, lyrics));
    }
}