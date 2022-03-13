using System;
using System.Threading.Tasks;
using MediatR;
using MusicBox.Artists.Commands;
using MusicBox.Artists.Querries;
using MusicBox.Artists.Querries.Dtos;

namespace MusicBox.Artists;

public class ArtistAppService : MusicBoxAppService, IArtistAppService
{
    private readonly IMediator _mediator;

    public ArtistAppService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<ArtistDto> CreateArtistAsync(CreateArtistCommand command)
    {
        return _mediator.Send(command);
    }

    public Task<ArtistDetailedDto> GetAsync(Guid id)
    {
        return _mediator.Send(new GetArtistQuery {Id = id});
    }
}