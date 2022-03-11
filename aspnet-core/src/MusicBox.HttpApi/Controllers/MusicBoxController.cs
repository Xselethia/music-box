using MusicBox.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MusicBox.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MusicBoxController : AbpControllerBase
{
    protected MusicBoxController()
    {
        LocalizationResource = typeof(MusicBoxResource);
    }
}
