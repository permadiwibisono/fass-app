using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FASSProject.Form
{
    public partial class Festival : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindGridViewFestival();
            }
            Object emp = Session["Login"];
            if (emp == null || !(emp is Employee))
            {
                Response.Redirect("~/login");
            }
        }
        void bindGridViewFestival()
        {
            var FestivalList = FestivalControl.getFestivalList();
            GridViewFestival.DataSource = FestivalList;
            GridViewFestival.DataBind();
        }
        void bindGridViewFestivalDetail(string id)
        {
            var FestivalDetailList = FestivalControl.getFestivalDetailList(id);
            GridViewPoinPenilaian.DataSource = FestivalDetailList;
            GridViewPoinPenilaian.DataBind();
            if (FestivalDetailList.Count<FestivalDetail>() <= 0 && id!="")
            {
                DataTable a = new DataTable();
                a.Columns.AddRange(new DataColumn[3]
                {
                    new DataColumn("FestivalID"),
                    new DataColumn("PoinID"),
                    new DataColumn("PoinPenilaian")
                }
                    );
                a.Rows.Add("","","");
                GridViewPoinPenilaian.DataSource = a;
                GridViewPoinPenilaian.DataBind();
                GridViewPoinPenilaian.Rows[0].Visible = false;
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int rowCount = 0;
                if (String.IsNullOrEmpty(HiddenID.Value))
                {
                    int i = FestivalModel.GetMaksID();
                    i++;
                    int temp = i;
                    string enol = "00";
                    int digit = 0;
                    while (temp != 0)
                    {
                        temp /= 10;
                        digit++;
                    }
                    if (digit == 1)
                        enol = "00";
                    else if (digit == 2)
                        enol = "0";
                    else if (digit == 3)
                        enol = "";
                    string newid = "FS" + enol + i;
                    FestivalClass newfestival = new FestivalClass(newid, TextBoxNamaFestival.Text, RadioButtonListSistem.Text, TextBoxDescription.Text);
                    Employee emp = (Employee)Session["Login"];
                    newfestival.CreatedBy = emp.employeeid;
                    newfestival.UpdatedBy = emp.employeeid;
                    rowCount=FestivalControl.InsertFestival(newfestival);
                    clearField();
                    bindGridViewFestival();
                    bindGridViewFestivalDetail("");
                }
                else
                {
                    FestivalClass newfestival = new FestivalClass(HiddenID.Value, TextBoxNamaFestival.Text, RadioButtonListSistem.Text, TextBoxDescription.Text);
                    Employee emp = (Employee)Session["Login"];
                    newfestival.UpdatedBy = emp.employeeid;
                    rowCount= FestivalControl.UpdateFestival(newfestival);
                    bindGridViewFestival();
                    clearField();
                    bindGridViewFestivalDetail("");
                }
                if (rowCount > 0)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('Data telah disimpan');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('" + ex.Message + "');", true);
            }
            
        }

        protected void ButtonNew_Click(object sender, EventArgs e)
        {
            clearField();
            bindGridViewFestivalDetail("");
        }

        protected void GridViewFestival_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewFestival.PageIndex = e.NewPageIndex;
            bindGridViewFestival();
        }

        protected void GridViewFestival_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                FestivalClass festdelete = new FestivalClass(GridViewFestival.DataKeys[e.RowIndex][0].ToString());
                Employee emp = (Employee)Session["Login"];
                festdelete.CreatedBy = emp.employeeid;
                festdelete.UpdatedBy = emp.employeeid;
                int i = FestivalControl.DeleteFestival(festdelete);
                if (i > 0)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('Data telah dihapus.');", true);
                bindGridViewFestival();                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('" + ex.Message + "');", true);
            }
        }

        protected void GridViewFestival_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GridViewFestival.SelectedDataKey[0].ToString();
            Label LabelNama = (Label)GridViewFestival.SelectedRow.FindControl("LabelNamaFestival");
            Label LabelSistemFest = (Label)GridViewFestival.SelectedRow.FindControl("LabelSistemFestival");
            Label LabelDesc = (Label)GridViewFestival.SelectedRow.FindControl("LabelDescription");
            HiddenID.Value = id;
            TextBoxNamaFestival.Text = LabelNama.Text;
            TextBoxDescription.Text = LabelDesc.Text;
            if (LabelSistemFest.Text == "Grup")
            {
                RadioButtonListSistem.Items[1].Selected = true;
                RadioButtonListSistem.Items[0].Selected = false;
            }
            else
            {
                RadioButtonListSistem.Items[0].Selected = true;
                RadioButtonListSistem.Items[1].Selected = false;
            }
            bindGridViewFestivalDetail(id);

        }

        void clearField()
        {
            HiddenID.Value = null;
            TextBoxNamaFestival.Text = "";
            TextBoxDescription.Text = "";
            RadioButtonListSistem.Items[0].Selected = true;
        }

        protected void GridViewPoinPenilain_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPoinPenilaian.PageIndex = e.NewPageIndex;
            bindGridViewFestivalDetail(HiddenID.Value);
        }

        protected void GridViewPoinPenilain_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                try
                {

                    GridViewRow row = GridViewPoinPenilaian.FooterRow;
                    int getId = FestivalModel.GetMaksID(HiddenID.Value);
                    getId++;
                    TextBox poinpenilaian = (TextBox)row.FindControl("TextBoxPoinPenilaian");
                    var fd = new FestivalDetail(HiddenID.Value, getId, poinpenilaian.Text);
                    Employee emp = (Employee)Session["Login"];
                    fd.CreatedBy = emp.employeeid;
                    fd.UpdatedBy = emp.employeeid;
                    int i = FestivalControl.InsertFestivalDetail(fd);
                    bindGridViewFestivalDetail(HiddenID.Value);
                    if (i > 0)
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('Data telah disimpan');", true);

                
                
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('" + ex.Message + "');", true);
                }
            }
        }

        protected void GridViewPoinPenilain_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = GridViewPoinPenilaian.DataKeys[e.RowIndex][0].ToString();
                string poinid = GridViewPoinPenilaian.DataKeys[e.RowIndex][1].ToString();
                var fd = new FestivalDetail(id, Int32.Parse(poinid));
                Employee emp = (Employee)Session["Login"];
                fd.UpdatedBy = emp.employeeid;
                int i = FestivalControl.DeleteFestivalDetail(fd);
                if (i > 0)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('Data telah dihapus.');", true);
                bindGridViewFestivalDetail(HiddenID.Value);
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('" + ex.Message + "');", true);                
            }
        }

        protected void GridViewPoinPenilain_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewPoinPenilaian.EditIndex = e.NewEditIndex;
            bindGridViewFestivalDetail(HiddenID.Value);
        }

        protected void GridViewPoinPenilaian_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                string id = GridViewPoinPenilaian.DataKeys[e.RowIndex][0].ToString();
                string poinid = GridViewPoinPenilaian.DataKeys[e.RowIndex][1].ToString();
                GridViewRow row = GridViewPoinPenilaian.Rows[e.RowIndex];
                TextBox poin = (TextBox)row.FindControl("TextBoxPoinPenilaian");
                var fd = new FestivalDetail(id, Int32.Parse(poinid), poin.Text);
                Employee emp = (Employee)Session["Login"];
                fd.UpdatedBy = emp.employeeid;
                int i = FestivalControl.UpdateFestivalDetail(fd);
                if (i > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('Data telah disimpan');", true);
                    GridViewPoinPenilaian.EditIndex = -1;
                    bindGridViewFestivalDetail(HiddenID.Value);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('" + ex.Message + "');", true);                
            }

        }
    }
}