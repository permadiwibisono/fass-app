using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FASSProject;

namespace FASSProject.Form
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Login"] = null;
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(TextBoxUserID.Text)&&!(String.IsNullOrEmpty(TextBoxPassword.Text)))
            {
                Employee newemp = new Employee(TextBoxUserID.Text, TextBoxPassword.Text);
                if (EmployeeControl.getEmployee(newemp) != null)
                {
                    Session["Login"] = newemp;
                    Response.Redirect("~");
                }
            }
        }
    }
}