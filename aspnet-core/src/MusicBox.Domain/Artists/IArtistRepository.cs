using System;
using Volo.Abp.Domain.Repositories;

namespace MusicBox.Artists;

public interface IArtistRepository : IRepository<Artist, Guid>
{
}