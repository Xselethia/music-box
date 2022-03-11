using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using MusicBox.Artists;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Xunit;

namespace MusicBox.EntityFrameworkCore.Samples;

/* This is just an example test class.
 * Normally, you don't test ABP framework code
 * (like default AppUser repository IRepository<AppUser, Guid> here).
 * Only test your custom repository methods.
 */
public class SampleRepositoryTests : MusicBoxEntityFrameworkCoreTestBase
{
    private readonly IRepository<IdentityUser, Guid> _appUserRepository;
    private readonly IRepository<SongDetail, Guid> _repository;

    public SampleRepositoryTests()
    {
        _repository = GetRequiredService<IRepository<SongDetail, Guid>>();
        _appUserRepository = GetRequiredService<IRepository<IdentityUser, Guid>>();
    }
    [Fact]
    public async Task Should_Query_View()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            //Act
            var songs = await _repository.ToListAsync();

            //Assert
            songs.Count.ShouldBe(3);
        });
    }

    [Fact]
    public async Task Should_Query_AppUser()
    {
        /* Need to manually start Unit Of Work because
         * FirstOrDefaultAsync should be executed while db connection / context is available.
         */
        await WithUnitOfWorkAsync(async () =>
        {
                //Act
                var adminUser = await (await _appUserRepository.GetQueryableAsync())
                .Where(u => u.UserName == "admin")
                .FirstOrDefaultAsync();

                //Assert
                adminUser.ShouldNotBeNull();
        });
    }
}
