using System.Web;
using System.Web.Mvc;

namespace WebAppLegacyShowcase
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
