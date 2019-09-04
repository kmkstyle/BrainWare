using System.Web.Mvc;

namespace Web
{
    /// <summary>
    /// Fiter configuration cloass
    /// </summary>
    public static class FilterConfig
    {
        /// <summary>
        /// Register global filters
        /// </summary>
        /// <param name="globalFilters">Global filters</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection globalFilters)
        {
            if (globalFilters != null)
            {
                globalFilters.Add(new HandleErrorAttribute());
            }
        }
    }
}
