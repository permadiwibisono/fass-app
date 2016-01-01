using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FASSProject
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session["Login"] = null;
            Response.Redirect("~/login");
        }
    }
}