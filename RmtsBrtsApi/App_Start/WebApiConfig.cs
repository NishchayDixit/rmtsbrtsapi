using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RmtsBrtsApi.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "getAllPickupPointsRmts",
                routeTemplate: "Api/RMTS_BRTS/{controller}/{action}",
                defaults: new { });
            
        }
    }
}