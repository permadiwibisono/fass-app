<%@ Page Title="Registration" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="FASSProject.Form.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavBar" runat="server">    
    <nav>
        <ul>
            <li>
                <a href="..">Home</a>
                            
            </li>
            <li class="selected">
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
    <div class="container">
        <div class="content">
        <div class="title">
            Registration
        </div>
            <div class="frame">
                <div class="kotak">
                    <table class="table">
                        <tr>
                            <td class="tdLeft">
                                Event ID
                            </td>
                            <td>
                                :
                            </td>
                            <td class="tdRight">
                                <asp:DropDownList runat="server" ID="DropDownListEventID" CssClass="ddl">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLeft">
                                Sistem
                            </td>
                            <td>
                                :
                            </td>
                            <td class="tdRight">
                                <%--<asp:RadioButtonList runat="server" ID="RadioButtonListSistem" AutoPostBack="true" 
                                    OnSelectedIndexChanged="RadioButtonListSistem_SelectedIndexChanged"
                                     RepeatDirection="Horizontal" CssClass="rdb">
                                    <asp:ListItem Selected="True">Perorangan</asp:ListItem>
                                    <asp:ListItem>Grup</asp:ListItem>
                                </asp:RadioButtonList>--%>
                                
                                <asp:DropDownList runat="server" ID="DropDownListSistem" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListSistem_SelectedIndexChanged" CssClass="ddl">
                                    <asp:ListItem>Perorangan</asp:ListItem>
                                    <asp:ListItem>Grup</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLeft">
                                Nama Peserta / Grup
                            </td>
                            <td>
                                :
                            </td>
                            <td class="tdRight">
                                <asp:TextBox runat="server" ID ="TextBoxNamaPeserta" CssClass="textmin"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLeft">
                                Umur
                            </td>
                            <td>
                                :
                            </td>
                            <td class="tdRight">
                                <asp:TextBox runat="server" ID ="TextBoxUmur" CssClass="textmin"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLeft">
                                Gender
                            </td>
                            <td>
                                :
                            </td>
                            <td class="tdRight">
                                <asp:RadioButtonList runat="server" ID="RadioButtonListGender"  RepeatDirection="Horizontal" CssClass="rdb">
                                    <asp:ListItem Selected="True">Female</asp:ListItem>
                                    <asp:ListItem>Male</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLeft">
                                Desa
                            </td>
                            <td>
                                :
                            </td>
                            <td class="tdRight">
                                <asp:DropDownList runat="server" ID="DropDownListDesa" CssClass="ddl">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLeft">
                                Kelompok
                            </td>
                            <td>
                                :
                            </td>
                            <td class="tdRight">
                                <asp:TextBox runat="server" ID ="TextBoxKelompok" CssClass="textmin"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLeft">
                                Festival
                            </td>
                            <td>
                                :
                            </td>
                            <td class="tdRight">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="DropDownListFestival" AutoPostBack="true" OnSelectedIndexChanged="DropDownListFestival_SelectedIndexChanged" CssClass="ddl">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DropDownListSistem"/>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="ButtonSubmit" Text="Submit" runat="server" CssClass="button" OnClick="ButtonSubmit_Click" />
                    <asp:Button ID="ButtonClear" Text="Clear" runat="server" CssClass="button" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
