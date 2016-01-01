using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FASSProject.Form
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Object emp = Session["Login"];
            if (emp == null || !(emp is Employee))
            {
                Response.Redirect("~/login");
            }
        }
    }
}