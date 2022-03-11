using Volo.Abp.Settings;

namespace MusicBox.Settings;

public class MusicBoxSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MusicBoxSettings.MySetting1));
    }
}
