using System;
using System.Collections.Generic;
using MusicBox.Albums;
using Volo.Abp.Application.Dtos;

namespace MusicBox.Artists.Querries.Dtos;

public class ArtistDetailedDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Image { get; set; }
    public string Biography { get; set; }
    public List<AlbumDetailedDto> Albums { get; set; }
}