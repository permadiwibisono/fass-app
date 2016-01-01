<%@ Page Title="Master Desa" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Desa.aspx.cs" Inherits="FASSProject.Form.Desa" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavBar" runat="server">    
    <nav>
        <ul>
            <li>
                <a href="..">Home</a>                            
            </li>
            <li>
                <a href="../reg">Registration</a>                            
            </li>
            <li>
                    <a href="#">Master</a>                            
                <ul>
                    <li class="selected">
                        <a href="../desa">Desa</a>                                    
                    </li>
                    <li>
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
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="HiddenID" runat="server" />
    <div class="container">
        <div class="content">
        <div class="title">
            Desa Master 
        </div>
            <div class="frame">
                <div class="kotakTitle">
                    Desa Detail
                </div>
                <div class="kotak">
                    <table class="table">
                        <tr>
                            <td class="tdLeft">
                                Nama Desa
                            </td>
                            <td>
                                :
                            </td>
                            <td class="tdRight">
                                <asp:TextBox runat="server" ID ="TextBoxNamaDesa" CssClass="textmin"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLeft">
                                Masjid Desa
                            </td>
                            <td>
                                :
                            </td>
                            <td class="tdRight">
                                <asp:TextBox runat="server" ID ="TextBoxMesjidDesa" CssClass="textmin"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLeft">
                                Alamat
                            </td>
                            <td>
                                :
                            </td>
                            <td class="tdRight">
                                <asp:TextBox runat="server" ID ="TextBoxAlamat" CssClass="textaddress" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="ButtonSubmit" Text="Submit" runat="server" CssClass="button" OnClick="ButtonSubmit_Click" />
                    <asp:Button ID="ButtonNew" Text="New" runat="server" CssClass="button" OnClick="ButtonNew_Click" />

                </div>
            </div>
            <div class="fullframe">
                <div class="kotakTitle">
                    Desa List
                </div>
                <div class="kotak">
                    <asp:GridView ID="GridViewDesa" runat="server" AllowPaging="true" BorderWidth="0px"
                PageSize="10" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found !" AutoGenerateColumns="false" 
                        DataKeyNames="DesaID" CssClass="mGrid" OnPageIndexChanging="GridViewDesa_PageIndexChanging" OnRowDeleting="GridViewDesa_RowDeleting" OnSelectedIndexChanged="GridViewDesa_SelectedIndexChanged">
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
                            <asp:TemplateField HeaderText="Nama Desa">
                                <ItemTemplate>
                                    <asp:Label ID="LabelNamaDesa" runat="server" Text='<%#Eval("NamaDesa") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mesjid Desa">
                                <ItemTemplate>
                                    <asp:Label ID="LabelMesjidDesa" runat="server" Text='<%#Eval("MesjidDesa") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Alamat Desa">
                                <ItemTemplate>
                                    <asp:Label ID="LabelAlamatDesa" runat="server" Text='<%#Eval("Alamat") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
