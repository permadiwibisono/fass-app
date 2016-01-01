using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FASSProject;

namespace FASSProject.Form
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDropdownListFestival();
                BindDropdownListDesa(); 
                BindDDLEvent();
            }
            Object emp = Session["Login"];
            if (emp == null || !(emp is Employee))
            {
                Response.Redirect("~/Form/Login.aspx");
            }
        }
        void clearField()
        {
            BindDropdownListFestival();
            BindDropdownListDesa();
            BindDDLEvent();
            RadioButtonListGender.Items[0].Selected = true;
            RadioButtonListGender.Items[1].Selected = false;
            TextBoxKelompok.Text = "";
            TextBoxNamaPeserta.Text = "";
            TextBoxUmur.Text = "";            
        }
        void BindDDLEvent()
        {
            var eventlist = EventFassControl.getEventList();
            DropDownListEventID.DataSource = eventlist;
            DropDownListEventID.DataTextField = "namaEvent";
            DropDownListEventID.DataValueField = "EventID";
            DropDownListEventID.DataBind();
        }
        void BindDropdownListDesa()
        {
            var list = DesaControl.getDesaList();
            DropDownListDesa.DataSource = list;
            DropDownListDesa.DataTextField = "NamaDesa";
            DropDownListDesa.DataValueField = "DesaID";
            DropDownListDesa.DataBind();   
        }
        void BindDropdownListFestival()
        {
            var list = FestivalControl.getFestivalList(DropDownListSistem.Text);
            DropDownListFestival.DataSource = list;
            DropDownListFestival.DataTextField = "NamaFestival";
            DropDownListFestival.DataValueField = "FestivalID";
            DropDownListFestival.DataBind();
        }

        protected void DropDownListFestival_SelectedIndexChanged(object sender, EventArgs e)
        {
            String a = DropDownListFestival.SelectedItem.Text;
        }

        protected void RadioButtonListSistem_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdownListFestival();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (DropDownListEventID.Text != "")
            {
                int i=0;
                try
                {
                    Guid pesid = Guid.NewGuid();
                    i = PesertaControl.InsertPeserta(new Peserta(pesid, TextBoxNamaPeserta.Text, TextBoxUmur.Text, RadioButtonListGender.Text, DropDownListDesa.Text, TextBoxKelompok.Text, DropDownListFestival.Text));
                    var festiDetails = FestivalControl.getFestivalDetailList(DropDownListFestival.Text);
                    if (festiDetails != null)
                    {
                        List<EventFassDetail> evFassDet = new List<EventFassDetail>();
                        foreach (FestivalDetail a in festiDetails)
                        {
                            evFassDet.Add(new EventFassDetail(Guid.Parse(DropDownListEventID.Text), pesid, a.festivalID, a.poinID,0));
                        }
                        int j = EventFassControl.InsertEvent(evFassDet);
                        if (j > 0)
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('Data telah disimpan');", true);
                        clearField();
                    }
                }
                catch(Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "showPop('" + ex.Message + "');", true);
                }
            }
        }
    }
}