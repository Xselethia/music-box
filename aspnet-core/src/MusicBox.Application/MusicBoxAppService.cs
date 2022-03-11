using System;
using System.Collections.Generic;
using System.Text;
using MusicBox.Localization;
using Volo.Abp.Application.Services;

namespace MusicBox;

/* Inherit your application services from this class.
 */
public abstract class MusicBoxAppService : ApplicationService
{
    protected MusicBoxAppService()
    {
        LocalizationResource = typeof(MusicBoxResource);
    }
}
