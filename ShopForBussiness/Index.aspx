<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ShopForBussiness.Products" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <style>
        body
        {
            margin: 0;
            padding:0;
        }

        form
        {
            width:80%;
            margin: 0 auto;
        }

        #logo
        {
            float: left;
            width: 80%;
            background-color: #ff6a00;
            height: 140px;
            font-size: 50px;
            text-align: center;
            font-weight:700;
            padding: 30px 0;
        }
        #loggedUser
        {
            width: 20%;
            float: left;
            background-color: #b6ff00;
            height: 140px;
            padding: 30px 0px;
            text-align: center;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="logo">Shop for Business</div>
        <div id="loggedUser"><%= LoggedUser != null ? "Witaj " + LoggedUser.Email.Split('@')[0] : "<a href='Login.aspx'>Zaloguj lub zarejestruj się!</a>" %>
            <asp:LinkButton ID="lbLogout" runat="server" OnClick="lbLogout_Click" Visible="false">Wyloguj!</asp:LinkButton>    
        </div>
        <div style="clear: both"></div>
        <div id="products">
            <asp:DataList ID="DataList1" runat="server">
                <ItemTemplate>  
                    <table cellpadding="2" cellspacing="0" border="1" style="width: 300px; height: 100px;   
                    border: dashed 2px #04AFEF; background-color: #FFFFFF">  
                        <tr>  
                            <td>  
                                <b>ID: </b><span class="city"><%# Eval("ID") %></span><br />  
                                <b>Name: </b><span class="postal"></span><br />  
                                <asp:Label runat="server">Hello</asp:Label>
                            </td>  
                        </tr>  
                    </table>  
                </ItemTemplate> 
            </asp:DataList>
        </div>

    </form>
</body>
</html>
