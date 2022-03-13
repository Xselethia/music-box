using System;
using MediatR;
using MusicBox.Artists.Querries.Dtos;

namespace MusicBox.Artists.Querries;

public class GetArtistQuery : IRequest<ArtistDetailedDto>
{
    public Guid Id { get; set; }
}