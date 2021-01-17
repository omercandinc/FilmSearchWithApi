using System.Web;
using System.Web.Mvc;

namespace MVCFilmSearchWithApi.LoginApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
