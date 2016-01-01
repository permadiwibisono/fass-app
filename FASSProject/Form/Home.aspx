<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FASSProject.Form.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavBar" runat="server">    
    <nav>
        <ul>
            <li class="selected">
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
    <div class="divGambar contenthome" >
    <br />
    <br />
    <br />
    <br />
        
        <div style="color:rgba(255,255,255,1);
				    font-weight: bold;
                    font-family:Roboto;
				    text-transform: uppercase;
				    text-shadow: 0 0 10px red;
				    text-align: center;z-index:5;">
            <h1 style="font-size:100px">
                WELCOME TO FASS!
            </h1>

        </div>
    </div>
</asp:Content>
