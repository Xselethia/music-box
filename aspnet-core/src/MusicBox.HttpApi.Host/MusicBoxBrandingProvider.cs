using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace MusicBox;

[Dependency(ReplaceServices = true)]
public class MusicBoxBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MusicBox";
}
