using SMS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SMS.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class SMSPageModel : AbpPageModel
{
    protected SMSPageModel()
    {
        LocalizationResourceType = typeof(SMSResource);
    }
}
