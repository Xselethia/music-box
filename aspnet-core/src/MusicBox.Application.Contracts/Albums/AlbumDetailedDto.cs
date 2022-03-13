using System;
using System.Collections.Generic;
using MusicBox.Songs;
using Volo.Abp.Application.Dtos;

namespace MusicBox.Albums;

public class AlbumDetailedDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public int ReleaseYear { get; set; }
    public string CoverImage { get; set; }
    public bool IsSingle { get; set; }
    public List<SongDto> Songs { get; set; }
}