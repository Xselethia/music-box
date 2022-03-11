using MusicBox.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MusicBox;

[DependsOn(
    typeof(MusicBoxEntityFrameworkCoreTestModule)
    )]
public class MusicBoxDomainTestModule : AbpModule
{

}
