using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MusicBox.Data;

/* This is used if database provider does't define
 * IMusicBoxDbSchemaMigrator implementation.
 */
public class NullMusicBoxDbSchemaMigrator : IMusicBoxDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
