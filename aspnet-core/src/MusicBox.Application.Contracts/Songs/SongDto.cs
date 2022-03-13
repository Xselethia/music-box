using System;
using Volo.Abp.Application.Dtos;

namespace MusicBox.Songs;

public class SongDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string Lyrics { get; set; }
    public string Genre { get; set; }
    public string SourceLink { get; set; }
    public string Suffix { get; set; }
    public int LengthInSeconds { get; set; }
}