using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MusicBox.Artists.Querries;
using MusicBox.Artists.Querries.Dtos;

namespace MusicBox.Artists.Handlers.Querries;

public class GetArtistQueryHandler : IRequestHandler<GetArtistQuery, ArtistDetailedDto>
{
    private readonly IArtistRepository _artistRepository;
    private readonly ManuelArtistMapper _mapper;

    public GetArtistQueryHandler(IArtistRepository artistRepository, ManuelArtistMapper mapper)
    {
        _artistRepository = artistRepository;
        _mapper = mapper;
    }

    public async Task<ArtistDetailedDto> Handle(GetArtistQuery request, CancellationToken cancellationToken = default)
    {
        var artist = await _artistRepository.GetAsync(request.Id, includeDetails: true, cancellationToken);
        return _mapper.MapToArtistDetailedDto(artist);
    }
}