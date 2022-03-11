using Volo.Abp.Modularity;

namespace MusicBox;

[DependsOn(
    typeof(MusicBoxApplicationModule),
    typeof(MusicBoxDomainTestModule)
    )]
public class MusicBoxApplicationTestModule : AbpModule
{

}
