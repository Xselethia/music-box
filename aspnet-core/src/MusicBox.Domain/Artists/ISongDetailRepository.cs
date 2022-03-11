using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MusicBox.Artists;

public interface ISongDetailRepository : IRepository<SongDetail, Guid>
{
    public Task CreateViewAsync();
}