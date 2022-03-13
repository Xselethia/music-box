using System;
using Volo.Abp.Application.Dtos;

namespace MusicBox.Artists.Querries.Dtos;

public class ArtistDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Image { get; set; }
    public string Biography { get; set; }
}