<%@ Page Title="Login"  Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FASSProject.Form.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/Login.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Background">
        <img id="img1" src="../Images/treetown-crowd.jpg" class="gambar" />
    </div>
    <div>
        <asp:Panel ID="PanelLogin" runat="server" CssClass="panelLogin">
            <table class="table">
                <tr>
                    <td>
                        User ID
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxUserID" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Password
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxPassword" CssClass="textbox" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                    <td>

                    </td>
                    <td>
                        <asp:Button ID="ButtonLogin" Text="Login" runat="server" CssClass="Button" OnClick="ButtonLogin_Click" />
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                    <td>

                    </td>
                    <td>
                        <div style="color:white;font-family:Roboto; font-size:10px;">
                            developed by <a href="https://permadiwibisono.github.io" style="text-decoration:none; color:orange">permadiwibisono</a> 
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--<div id="footer">
            
        </div>--%>
    </div>
    </form>
</body>
</html>
