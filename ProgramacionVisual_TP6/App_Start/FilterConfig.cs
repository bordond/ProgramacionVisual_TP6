using System.Web;
using System.Web.Mvc;

namespace ProgramacionVisual_TP6
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
