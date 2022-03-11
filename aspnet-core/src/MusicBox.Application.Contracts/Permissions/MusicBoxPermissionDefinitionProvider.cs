using MusicBox.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MusicBox.Permissions;

public class MusicBoxPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MusicBoxPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MusicBoxPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MusicBoxResource>(name);
    }
}
