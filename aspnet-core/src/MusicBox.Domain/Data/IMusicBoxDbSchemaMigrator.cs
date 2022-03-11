using System.Threading.Tasks;

namespace MusicBox.Data;

public interface IMusicBoxDbSchemaMigrator
{
    Task MigrateAsync();
}
