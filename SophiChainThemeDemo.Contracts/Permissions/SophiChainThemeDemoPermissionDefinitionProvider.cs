using SophiChainThemeDemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace SophiChainThemeDemo.Permissions;

public class SophiChainThemeDemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SophiChainThemeDemoPermissions.GroupName);



        //Define your own permissions here. Example:
        //myGroup.AddPermission(SophiChainThemeDemoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SophiChainThemeDemoResource>(name);
    }
}
