<%@ Page Title="Master Festival" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Festival.aspx.cs" Inherits="FASSProject.Form.Festival" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavBar" runat="server">    
    <nav>
        <ul>
            <li >
                <a href="..">Home</a>
                            
            </li>
            <li>
                <a href="../reg">Registration</a>
                            
            </li>
            <li>
                    <a href="#">Master</a>
                            
                <ul>
                    <li>
                    <a href="../desa">Desa</a>
                                    
                    </li>
                    <li class="selected">
                    <a href="../festival">Festival</a>
                                    
                    </li>
                </ul>
            </li>
            <li>
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
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="HiddenID" runat="server" />
    <div class="container">
        <div class="content">
            <div class="title">
                Festival Master
            </div>
            <div class="fullframe">
                <div class="kotakTitle">
                    Festival List
                </div>
                <div class="kotak">
                    <asp:GridView ID="GridViewFestival" runat="server" AllowPaging="true" BorderWidth="0px"
                PageSize="5" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found !" AutoGenerateColumns="false" 
                        DataKeyNames="FestivalID" CssClass="mGrid" OnPageIndexChanging="GridViewFestival_PageIndexChanging" OnRowDeleting="GridViewFestival_RowDeleting"
                        OnSelectedIndexChanged="GridViewFestival_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="ButtonSelect" Text="Select" CommandName="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="ButtonDelete" Text="Delete" CommandName="Delete" />
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
            <div class="frame">
                <div class="kotakTitle">
                    Festival Detail
                </div>
                <div class="kotak">                
                    <table class="table">
                        <tr>
                            <td class="tdLeft">
                                Nama Festival
                            </td>
                            <td>
                                :
                            </td>
                            <td class="tdRight">
                                <asp:TextBox runat="server" ID ="TextBoxNamaFestival" CssClass="textmin"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLeft">
                                Sistem Festival
                            </td>
                            <td>
                                :
                            </td>
                            <td class="tdRight">
                                <asp:RadioButtonList runat="server" ID="RadioButtonListSistem" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True">Perorangan</asp:ListItem>
                                    <asp:ListItem>Grup</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLeft">
                                Description
                            </td>
                            <td>
                                :
                            </td>
                            <td class="tdRight">
                                <asp:TextBox runat="server" ID ="TextBoxDescription" CssClass="textaddress" TextMode="MultiLine" MaxLength="160"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="ButtonSubmit" Text="Submit" runat="server" CssClass="button" OnClick="ButtonSubmit_Click" />
                    <asp:Button ID="ButtonNew" Text="New" runat="server" CssClass="button" OnClick="ButtonNew_Click" />
                </div>
            </div>
            <div class="frame">
                <div class="kotakTitle">
                    Poin Penilaian
                </div>
                <div class="kotak">
                    <asp:GridView ID="GridViewPoinPenilaian" runat="server" ShowFooter="true" AllowPaging="true" BorderWidth="0px"
                PageSize="3" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found !" AutoGenerateColumns="false" 
                        DataKeyNames="FestivalID, PoinID" CssClass="mGrid" OnPageIndexChanging="GridViewPoinPenilain_PageIndexChanging"
                        OnRowCommand="GridViewPoinPenilain_RowCommand" OnRowDeleting="GridViewPoinPenilain_RowDeleting" 
                        OnRowEditing="GridViewPoinPenilain_RowEditing" OnRowUpdating="GridViewPoinPenilaian_RowUpdating">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="ButtonEdit" Text="Edit" CommandName="Edit" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button runat="server" ID="ButtonSave" Text="Save" CommandName="Update" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Button runat="server" ID="ButtonAdd" Text="Add" CommandName="Add" />                                
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:Button runat="server" ID="ButtonDelete" Text="Delete" CommandName="Delete" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Poin Penilainan">
                                <ItemTemplate>
                                    <asp:Label ID="LabelPoinPenilaian" runat="server" Text='<%#Eval("PoinPenilaian") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxPoinPenilaian" runat="server" Text='<%#Eval("PoinPenilaian") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TextBoxPoinPenilaian" runat="server" ></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
