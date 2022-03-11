using MusicBox.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace MusicBox.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MusicBoxEntityFrameworkCoreModule),
    typeof(MusicBoxApplicationContractsModule)
    )]
public class MusicBoxDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
