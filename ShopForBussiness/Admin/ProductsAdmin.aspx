<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsAdmin.aspx.cs" Inherits="ShopForBussiness.Admin.ProductsAdmin" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body
        {
            margin: 0;
            padding:0;
            background-color: #808080;
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
        #products
        {
            background-color: green;
            padding: 30px;
        }

        h1
        {
            margin: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="logo">Shop for Business</div>
        <div id="loggedUser">Panel admina:<br />
            <a href="./ProductsAdmin.aspx">Produkty</a><br />
            <a href="./OrdersAdmin.aspx">Zamówienia</a><br />
            <a href="./UsersAdmin.aspx">Produkty</a><br />
            <asp:LinkButton ID="lbLogout" runat="server" OnClick="lbLogout_Click">Wyloguj!</asp:LinkButton>
        </div>
        <div style="clear: both"></div>
        <div id="products">
            <h1>Produkty</h1>
            <asp:DataList ID="DataList1" runat="server">
                <ItemTemplate>

                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>
