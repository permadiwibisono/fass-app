<%@ Page Title="FASS" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Fass.aspx.cs" Inherits="FASSProject.Form.Fass" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavBar" runat="server">
    <nav>
        <ul>
            <li>
                <a href="..">Home</a>
                            
            </li>
            <li >
                <a href="../reg">Registration</a>
                            
            </li>
            <li>
                    <a href="#">Master</a>
                            
                <ul>
                    <li>
                    <a href="../desa">Desa</a>
                                    
                    </li>
                    <li>
                    <a href="../festival">Festival</a>
                                    
                    </li>
                </ul>
            </li>
            <li class="selected">
                <a href="../fass">FASS</a>
            </li>
            <%--<li>
                    <a href="#">Setting</a>
                            
                <ul>
                    <li> 
                        <a href="#">Change Password</a>
                    </li>
                    <li>
                        <a href="#">Logout</a>
                    </li>
                </ul>
            </li>--%>
        </ul>
    </nav>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="containerTab">
   <ajaxToolkit:TabContainer ID ="TabContainer1" runat="server" CssClass="TabStyle" ActiveTabIndex="0" Height="500px" BorderWidth="0px">
       <ajaxToolkit:TabPanel ID ="TabPanelPilihFestival" HeaderText="Pilih Festival" runat="server">
           <ContentTemplate>
               <div class="contentTab">
                   <div class="frame">
                       <div class="kotakTitle">
                           Pilih Event
                       </div>
                       <div class="kotak">
                           <asp:Panel ID="PilihEvent" runat="server">
                               <table class="table">
                                   <tr>
                                        <td class="tdLeft">
                                            Event
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td class="tdRight">
                                            <asp:DropDownList runat="server" ID="DropDownListEventID" CssClass="ddl">
                                            </asp:DropDownList>
                                        </td>
                                       <td>                                           
                                           <asp:Button ID="ButtonGo" Text="Go" runat="server" OnClick="ButtonGo_Click" />
                                       </td>
                                    </tr>
                               </table>
                               <div id="DivBuatBaru" runat="server"> Jika tidak ada event bisa di buat <asp:LinkButton runat="server" Text="disini" ID="LinkButtonDisini" OnClick="LinkButtonDisini_Click"></asp:LinkButton></div> 
                           </asp:Panel>
                        <asp:Panel ID="PanelBuatEvent" runat="server" Visible="false">
                            <table class="table">
                                <tr>
                                    <td class="tdLeft">
                                        Event 
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td class="tdRight">
                                        <asp:TextBox ID="TextBoxEventID" runat="server" CssClass="textmin"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                    </td>
                                    <td>

                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonSubmit" Text="Submit" runat="server" OnClick="ButtonSubmit_Click" />
                                        <asp:Button ID="ButtonCancel" Text="Cancel" runat="server" OnClick="ButtonCancel_Click" />
                                    </td>
                                </tr>
                            </table>

                        </asp:Panel>
                       </div>

                   </div>
                   <div class="fullframe">
                       <div class="kotakTitle">
                           Daftar Festival
                       </div>
                       <div class="kotak">
                           
                    <asp:GridView ID="GridViewFestival" runat="server" AllowPaging="true" BorderWidth="0px"
                PageSize="5" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found !" AutoGenerateColumns="false" 
                        DataKeyNames="FestivalID" CssClass="mGrid" OnSelectedIndexChanged="GridViewFestival_SelectedIndexChanged" OnPageIndexChanging="GridViewFestival_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="ButtonSelect" Text="Select" CommandName="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nama Festival">
                                <ItemTemplate>
                                    <asp:Label ID="LabelNamaFestival" runat="server" Text='<%#Eval("NamaFestival") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sistem Festival">
                                <ItemTemplate>
                                    <asp:Label ID="LabelSistemFestival" runat="server" Text='<%#Eval("SistemPermainan") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="LabelDescription" runat="server" Text='<%#Eval("Desc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                       </div>
                   </div>
               </div>
           </ContentTemplate>
       </ajaxToolkit:TabPanel>
       <ajaxToolkit:TabPanel ID ="TabPanelFestival" HeaderText="Festival" runat="server">
           <ContentTemplate>
               <div class="contentTab">
                   <div class="fullframe">
                       <div class="kotakTitle">
                           <asp:Label ID="LabelFestival" runat="server" Text=" ...."></asp:Label>
                       </div>
                   </div>
                   
                   <div class="fullframe">
                       <div class="kotakTitle">
                           Daftar Peserta
                       </div>
                       <div class="kotak">
                           
                    <asp:GridView ID="GridViewPeserta" runat="server" AllowPaging="true" BorderWidth="0px"
                PageSize="20" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found !" AutoGenerateColumns="false" 
                        DataKeyNames="EventID,FestivalID,PesertaID" CssClass="mGrid" OnSelectedIndexChanged="GridViewPeserta_SelectedIndexChanged" OnPageIndexChanging="GridViewPeserta_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="ButtonSelect" Text="Select" CommandName="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nama Peserta">
                                <ItemTemplate>
                                    <asp:Label ID="LabelNamaPeserta" runat="server" Text='<%#Eval("NamaPeserta") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Desa" SortExpression="NamaDesa">
                                <ItemTemplate>
                                    <asp:Label ID="LabelNamaDesa" runat="server" Text='<%#Eval("NamaDesa") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Umur">
                                <ItemTemplate>
                                    <asp:Label ID="LabelUmur" runat="server" Text='<%#Eval("Umur") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Score" SortExpression="TotalScore">
                                <ItemTemplate>
                                    <asp:Label ID="LabelTotalScore" runat="server" Text='<%#Eval("TotalScore") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                       </div>
                   </div>
               </div>
           </ContentTemplate>
       </ajaxToolkit:TabPanel>
       <ajaxToolkit:TabPanel ID ="TabPanelScoring" HeaderText="Scoring" runat="server">
           <ContentTemplate>
               
               <div class="contentTab">
                   <div class="fullframe">
                       <div class="kotakTitle">
                           <asp:Label ID="Label1" runat="server" Text="Peserta"></asp:Label>'s Score
                       </div>
                   </div>
                   
                   <div class="fullframe">
                       <div class="kotakTitle">
                           Poin Penilaian
                       </div>
                       <div class="kotak">
                           
                    <asp:GridView ID="GridViewScoring" runat="server" AllowPaging="true" BorderWidth="0px"
                PageSize="10" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found !" AutoGenerateColumns="false" 
                        DataKeyNames="EventID,FestivalID, PesertaID, PoinID" CssClass="mGrid" OnPageIndexChanging="GridViewScoring_PageIndexChanging" OnRowCommand="GridViewScoring_RowCommand" 
                        OnRowEditing="GridViewScoring_RowEditing" OnRowUpdating="GridViewScoring_RowUpdating" OnRowCancelingEdit="GridViewScoring_RowCancelingEdit">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="ButtonEdit" Text="Edit" CommandName="Edit" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button runat="server" ID="ButtonSave" Text="Save" CommandName="Update" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:Button runat="server" ID="ButtonCancel" Text="Cancel" CommandName="Cancel" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Poin Penilaian">
                                <ItemTemplate>
                                    <asp:Label ID="LabelPoinPenilaian" runat="server" Text='<%#Eval("PoinPenilaian") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Score">
                                <ItemTemplate>
                                    <asp:Label ID="LabelScore" runat="server" Text='<%#Eval("Skor") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxScore" runat="server" Text='<%#Eval("Skor") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                       </div>
                   </div>
               </div>
           </ContentTemplate>
       </ajaxToolkit:TabPanel>
       <ajaxToolkit:TabPanel ID ="TabPanelDesaScore" HeaderText="Desa Score" runat="server">
           <ContentTemplate>
               
               <div class="contentTab">                   
                   <div class="fullframe">
                       <div class="kotakTitle">
                           Desa Score
                       </div>
                       <div class="kotak">
                           
                    <asp:GridView ID="GridViewDesaScore" runat="server" AllowPaging="true" BorderWidth="0px"
                PageSize="10" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found !" AutoGenerateColumns="false" 
                        DataKeyNames="EventID,DesaID" CssClass="mGrid" >
                        <Columns>
                            <asp:TemplateField HeaderText="Nama Desa">
                                <ItemTemplate>
                                    <asp:Label ID="LabelNamaDesa" runat="server" Text='<%#Eval("NamaDesa") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Score">
                                <ItemTemplate>
                                    <asp:Label ID="LabelScore" runat="server" Text='<%#Eval("TotalScore") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                       </div>
                   </div>
               </div>
           </ContentTemplate>
       </ajaxToolkit:TabPanel>
   </ajaxToolkit:TabContainer>

    </div>
</asp:Content>
