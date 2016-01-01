using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
namespace FASSProject
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);

        }

        static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("login", "login", "~/Form/Login.aspx");
            routes.MapPageRoute("home", "", "~/Form//Home.aspx");
            routes.MapPageRoute("desa", "desa", "~/Form/Desa.aspx");
            routes.MapPageRoute("fass", "fass", "~/Form/Fass.aspx");
            routes.MapPageRoute("festival", "festival", "~/Form/Festival.aspx");
            routes.MapPageRoute("registrasion", "reg", "~/Form/Registration.aspx");
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}