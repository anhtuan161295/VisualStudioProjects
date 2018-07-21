using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lab06
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start()
        {
            int cnt = 0;
            //int visit = 0;
            System.IO.StreamReader sr = new StreamReader(Server.MapPath("~/Count.txt"));
            cnt = int.Parse(sr.ReadLine());
            sr.Close();
            Application.Lock();
            //visit++;
            Session["visitor"] = cnt;
            Application.UnLock();
            //cnt = visit;
            cnt++;
            System.IO.StreamWriter sw = new StreamWriter(Server.MapPath("~/Count.txt"));
            sw.WriteLine(cnt);
            sw.Flush();
            sw.Close();
        }
    }
}