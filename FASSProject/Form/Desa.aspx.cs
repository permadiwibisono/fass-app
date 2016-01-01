using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FASSProject;

namespace FASSProject.Form
{
    public partial class Desa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindGridViewDesa();
            }

            Object emp = Session["Login"];
            if (emp == null || !(emp is Employee))
            {
                Response.Redirect("~/login");
            }
        }
        void bindGridViewDesa()
        {
            var desaList = DesaControl.getDesaList();
            GridViewDesa.DataSource = desaList;
            GridViewDesa.DataBind();
        }

        protected void GridViewDesa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewDesa.PageIndex = e.NewPageIndex;
            bindGridViewDesa();
        }

        protected void GridViewDesa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try {

                DesaClass desadelete = new DesaClass(GridViewDesa.DataKeys[e.RowIndex][0].ToString());
                Employee emp = (Employee)Session["Login"];
                desadelete.CreatedBy = emp.employeeid;
                desadelete.UpdatedBy = emp.employeeid;
                int i = DesaControl.DeleteDesa(desadelete);
                if (i > 0)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('Data telah dihapus.');", true);
                bindGridViewDesa();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('" + ex.Message + "');", true);                
            }
        }

        protected void GridViewDesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GridViewDesa.SelectedDataKey[0].ToString();
            Label LabelNama = (Label)GridViewDesa.SelectedRow.FindControl("LabelNamaDesa");
            Label LabelMesjid = (Label)GridViewDesa.SelectedRow.FindControl("LabelMesjidDesa");
            Label LabelAlamat = (Label)GridViewDesa.SelectedRow.FindControl("LabelAlamatDesa");
            HiddenID.Value = id;
            TextBoxNamaDesa.Text = LabelNama.Text;
            TextBoxMesjidDesa.Text = LabelMesjid.Text;
            TextBoxAlamat.Text = LabelAlamat.Text;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try {
                int rowCount = 0;
                if (String.IsNullOrEmpty(HiddenID.Value))
                {
                    int i = DesaModel.GetMaksID();
                    i++;
                    string newid = "DS" + i;
                    DesaClass newdesa = new DesaClass(newid, TextBoxNamaDesa.Text, TextBoxMesjidDesa.Text, TextBoxAlamat.Text);
                    Employee emp = (Employee)Session["Login"];
                    newdesa.CreatedBy = emp.employeeid;
                    newdesa.UpdatedBy = emp.employeeid;
                    rowCount=DesaControl.InsertDesa(newdesa);
                    clearField();
                    bindGridViewDesa();
                }
                else
                {
                    DesaClass newdesa = new DesaClass(HiddenID.Value, TextBoxNamaDesa.Text, TextBoxMesjidDesa.Text, TextBoxAlamat.Text);
                    Employee emp = (Employee)Session["Login"];
                    newdesa.CreatedBy = emp.employeeid;
                    newdesa.UpdatedBy = emp.employeeid;
                    rowCount = DesaControl.UpdateDesa(newdesa);
                    bindGridViewDesa();
                    clearField();
                }
                if (rowCount > 0)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('Data telah disimpan');", true);

            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('"+ex.Message+"');", true);
            }
            
        }
        void clearField()
        {
            HiddenID.Value = null;
            TextBoxNamaDesa.Text = "";
            TextBoxMesjidDesa.Text = "";
            TextBoxAlamat.Text = "";
        }

        protected void ButtonNew_Click(object sender, EventArgs e)
        {
            clearField();
        }
    }
}