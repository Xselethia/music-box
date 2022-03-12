using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace MusicBox.Artists;

public class SongMetaData : ValueObject
{
    public string Suffix { get; private set; }
    public int LengthInSeconds { get; private set; }

    public SongMetaData(int lengthInSeconds, string suffix = "")
    {
        Suffix = Check.Length(suffix, nameof(suffix), MusicBoxConstants.Song.MetadataSuffixMaxLength);
        LengthInSeconds = lengthInSeconds;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return LengthInSeconds;
        yield return Suffix;
    }
}