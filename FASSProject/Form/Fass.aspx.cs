using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FASSProject;

namespace FASSProject.Form
{
    public partial class Fass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDDLEvent();
                if (!string.IsNullOrEmpty(DropDownListEventID.Text.ToString()))
                {
                    BindGridViewDesaScore(Guid.Parse(DropDownListEventID.Text));
                    ButtonGo.Visible = true;
                }
                else
                {
                    ButtonGo.Visible = false;
                }
            }

            Object emp = Session["Login"];
            if (emp == null || !(emp is Employee))
            {
                Response.Redirect("~/login");
            }
        }
        void BindGridViewPoin(EventFassDetailParent ev)
        {
            var poinList = EventFassControl.getPoinPenilaianByPeserta(ev);
            GridViewScoring.DataSource = poinList;
            GridViewScoring.DataBind();
        }
        void BindGridViewPoin()
        {
            Label1.Text = "Peserta";
            GridViewScoring.DataSource = null;
            GridViewScoring.DataBind();
        }
        void BindGridViewPeserta(FestivalClass f, Guid evID)
        {
            var pesertaList = EventFassControl.getPesertaListByFestival(f, evID);
            GridViewPeserta.DataSource = pesertaList;
            GridViewPeserta.DataBind();
        }
        void BindGridViewDesaScore(Guid evID)
        {
            var DesaList = EventFassModel.getPesertaListDesaScore(evID);
            GridViewDesaScore.DataSource = DesaList;
            GridViewDesaScore.DataBind();
        }
        void BindDDLEvent()
        {
            var eventlist = EventFassControl.getEventList();
            DropDownListEventID.DataSource = eventlist;
            DropDownListEventID.DataTextField = "namaEvent";
            DropDownListEventID.DataValueField = "eventID";
            DropDownListEventID.DataBind();
        }
        void BindGVFestival()
        {
            var festivalList = FestivalControl.getFestivalList();
            GridViewFestival.DataSource = festivalList;
            GridViewFestival.DataBind();
        }

        protected void LinkButtonDisini_Click(object sender, EventArgs e)
        {
            TextBoxEventID.Text = "";
            PanelBuatEvent.Visible = true;
            PilihEvent.Visible = false;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                int i = EventFassControl.InsertEvent(new EventFass(Guid.NewGuid(), DateTime.Now, false, TextBoxEventID.Text));
                BindDDLEvent();
                BindGridViewDesaScore(Guid.Parse(DropDownListEventID.Text));
                PilihEvent.Visible = true;
                PanelBuatEvent.Visible = false;
                ButtonGo.Visible = true;
                if (i > 0)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('Data telah disimpan');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('" + ex.Message + "');", true);                
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            TextBoxEventID.Text = "";
            PanelBuatEvent.Visible = false;
            PilihEvent.Visible = true;

        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            BindGVFestival();
            BindGridViewDesaScore(Guid.Parse(DropDownListEventID.Text));
            DivBuatBaru.Visible = false;
            ButtonGo.Visible = false;
            DropDownListEventID.Enabled = false;
        }

        protected void GridViewPeserta_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label LabelNamaPeserta = (Label)GridViewPeserta.SelectedRow.FindControl("LabelNamaPeserta");
            Label1.Text = LabelNamaPeserta.Text;
            BindGridViewPoin(new EventFassDetailParent(Guid.Parse(GridViewPeserta.SelectedDataKey[0].ToString()), Guid.Parse(GridViewPeserta.SelectedDataKey[2].ToString()), GridViewPeserta.SelectedDataKey[1].ToString()));
            TabContainer1.ActiveTabIndex = 2;
        }

        protected void GridViewPeserta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPeserta.PageIndex = e.NewPageIndex;
            BindGridViewPeserta(new FestivalClass(GridViewFestival.SelectedDataKey[0].ToString()), Guid.Parse(DropDownListEventID.Text));
        }

        protected void GridViewFestival_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label NamaFestival = (Label)GridViewFestival.SelectedRow.FindControl("LabelNamaFestival");
            LabelFestival.Text = NamaFestival.Text;
            BindGridViewPeserta(new FestivalClass(GridViewFestival.SelectedDataKey[0].ToString()), Guid.Parse(DropDownListEventID.Text));
            TabContainer1.ActiveTabIndex = 1;
            BindGridViewPoin();

        }

        protected void GridViewFestival_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewFestival.PageIndex = e.NewPageIndex;
            BindGVFestival();

        }

        protected void GridViewScoring_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewScoring.PageIndex = e.NewPageIndex;
            BindGridViewPoin(new EventFassDetailParent(Guid.Parse(GridViewPeserta.SelectedDataKey[0].ToString()), Guid.Parse(GridViewPeserta.SelectedDataKey[2].ToString()), GridViewPeserta.SelectedDataKey[1].ToString()));
        }

        protected void GridViewScoring_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridViewScoring_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewScoring.EditIndex = e.NewEditIndex;
            BindGridViewPoin(new EventFassDetailParent(Guid.Parse(GridViewPeserta.SelectedDataKey[0].ToString()), Guid.Parse(GridViewPeserta.SelectedDataKey[2].ToString()), GridViewPeserta.SelectedDataKey[1].ToString()));
        }

        protected void GridViewScoring_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                TextBox TextScore = (TextBox) GridViewScoring.Rows[e.RowIndex].FindControl("TextBoxScore");
                Double score;
                if(Double.TryParse(TextScore.Text,out score))
                {
                    Guid EventID = Guid.Parse(GridViewScoring.DataKeys[e.RowIndex][0].ToString());
                    string FestivalID = GridViewScoring.DataKeys[e.RowIndex][1].ToString();
                    Guid PesertaID = Guid.Parse(GridViewScoring.DataKeys[e.RowIndex][2].ToString());
                    int PoinID = Int32.Parse(GridViewScoring.DataKeys[e.RowIndex][3].ToString());
                    int i=EventFassControl.UpdateScore(new EventFassDetail(EventID,PesertaID,FestivalID,PoinID,score));
                    if(i>0)
                    {
                        GridViewScoring.EditIndex = -1;
                        BindGridViewPoin(new EventFassDetailParent(Guid.Parse(GridViewPeserta.SelectedDataKey[0].ToString()), Guid.Parse(GridViewPeserta.SelectedDataKey[2].ToString()), GridViewPeserta.SelectedDataKey[1].ToString()));
                        BindGridViewPeserta(new FestivalClass(GridViewFestival.SelectedDataKey[0].ToString()), Guid.Parse(DropDownListEventID.Text));
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('Data telah disimpan');", true);
                        BindGridViewDesaScore(Guid.Parse(DropDownListEventID.Text));
                    }

                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('" + ex.Message + "');", true); 
            }

        }

        protected void GridViewScoring_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewScoring.EditIndex = -1;
            BindGridViewPoin(new EventFassDetailParent(Guid.Parse(GridViewPeserta.SelectedDataKey[0].ToString()), Guid.Parse(GridViewPeserta.SelectedDataKey[2].ToString()), GridViewPeserta.SelectedDataKey[1].ToString()));
        }

    }
}