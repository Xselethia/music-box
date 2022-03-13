using System;
using System.Threading.Tasks;
using MusicBox.Artists.Commands;
using MusicBox.Artists.Querries.Dtos;
using Volo.Abp.Application.Services;

namespace MusicBox.Artists;

public interface IArtistAppService : IApplicationService
{
    public Task<ArtistDto> CreateArtistAsync(CreateArtistCommand command);
    public Task<ArtistDetailedDto> GetAsync(Guid id);
}