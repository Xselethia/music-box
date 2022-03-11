using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;

namespace MusicBox.Artists;

public class Song : Entity<Guid>, IHasExtraProperties
{
    public string Name { get; private set; }
    public string Lyrics { get; private set; }
    public string Genre { get; private set; }
    public string SourceLink { get; private set; }
    public SongMetaData MetaData { get; private set; }
    public ExtraPropertyDictionary ExtraProperties { get; }

    private Song()
    {
    }

    public Song(Guid id,
        [NotNull] string name,
        [NotNull] string sourceLink,
        [NotNull] string genre,
        SongMetaData metadata,
        string lyrics = null)
        : base(id)
    {
        Name = Check.NotNullOrEmpty(name, nameof(name), MusicBoxConstants.Song.NameMaxLength);
        SourceLink = Check.NotNullOrEmpty(sourceLink, nameof(sourceLink), MusicBoxConstants.Song.SourceLinkMaxLength);
        Genre = Check.NotNullOrEmpty(genre, nameof(genre), MusicBoxConstants.Song.GenreMaxLength);
        Lyrics = Check.NotNullOrEmpty(lyrics, nameof(lyrics), MusicBoxConstants.Song.LyricsMaxLength);
        ValidateMetadata(metadata);
        ExtraProperties = new ExtraPropertyDictionary();
    }

    private void ValidateMetadata(SongMetaData metadata)
    {
        MetaData = new SongMetaData(metadata.Suffix, metadata.LengthInSeconds);
    }
}