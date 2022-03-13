using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MusicBox.Artists.Commands;
using MusicBox.Artists.Querries.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace MusicBox.Artists.Handlers.Commands;

public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, ArtistDto>
{
    private readonly IRepository<Artist, Guid> _artistRepository;
    private readonly IGuidGenerator _guidGenerator;
    private readonly ManuelArtistMapper _mapper;

    public CreateArtistCommandHandler(IRepository<Artist, Guid> artistRepository, IGuidGenerator guidGenerator, ManuelArtistMapper mapper)
    {
        _artistRepository = artistRepository;
        _guidGenerator = guidGenerator;
        _mapper = mapper;
    }

    public async Task<ArtistDto> Handle(CreateArtistCommand request, CancellationToken cancellationToken = default)
    {
        var newArtist = new Artist(_guidGenerator.Create(), request.Name, request.LastName, request.Image,
            request.Biography);

        var result = await _artistRepository.InsertAsync(newArtist, autoSave: true, cancellationToken);

        return _mapper.MapToArtistDto(result);
    }
}