using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicBox.Data;
using Volo.Abp.DependencyInjection;

namespace MusicBox.EntityFrameworkCore;

public class EntityFrameworkCoreMusicBoxDbSchemaMigrator
    : IMusicBoxDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMusicBoxDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the MusicBoxDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MusicBoxDbContext>()
            .Database
            .MigrateAsync();
    }
}
