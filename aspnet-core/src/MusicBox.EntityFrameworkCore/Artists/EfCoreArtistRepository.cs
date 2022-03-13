using System;
using System.Linq;
using System.Threading.Tasks;
using MusicBox.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MusicBox.Artists;

public class EfCoreArtistRepository : EfCoreRepository<MusicBoxDbContext, Artist, Guid>,
    IArtistRepository
{
    public EfCoreArtistRepository(IDbContextProvider<MusicBoxDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Artist>> WithDetailsAsync()
    {
        return (await GetQueryableAsync())
            .IncludeSongs();
    }
}