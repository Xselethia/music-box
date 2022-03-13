using MediatR;
using MusicBox.Artists.Querries;
using MusicBox.Artists.Querries.Dtos;

namespace MusicBox.Artists.Commands;

public class CreateArtistCommand : IRequest<ArtistDto>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Image { get; set; }
    public string Biography { get; set; }
}