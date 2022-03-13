using System;
using Volo.Abp.Application.Dtos;

namespace MusicBox.Albums;

public class AlbumDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public int ReleaseYear { get; set; }
    public string CoverImage { get; set; }
    public bool IsSingle { get; set; }
}