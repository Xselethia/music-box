using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace MusicBox.Artists;

public class SongMetaData : ValueObject
{
    public string Suffix { get; private set; }
    public int LengthInSeconds { get; private set; }

    public SongMetaData([NotNull] string suffix, int lengthInSeconds)
    {
        Suffix = Check.NotNullOrEmpty(suffix, nameof(suffix), MusicBoxConstants.Song.MetadataSuffixMaxLength);
        LengthInSeconds = lengthInSeconds;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Suffix;
        yield return LengthInSeconds;
    }
}