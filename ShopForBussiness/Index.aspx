<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ShopForBussiness.Products" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shop For Bussiness</title>
    <link href="https://fonts.googleapis.com/css?family=Roboto&display=swap&subset=latin-ext" rel="stylesheet">
    <style>
        body
        {
            margin: 0;
            padding:0;
            font-family: 'Roboto', sans-serif;
            background: #edeff1;
        }

        #logo
        {
            float: left;
            width: 20%;
            font-size: 20px;
            font-weight: 700;
            padding: 20px;
            color: darkorange;
        }

        #logo a
        {
            text-decoration:none;
            color: darkorange;
        }
        #logo-fluid-container
        {
            border-bottom: 2px solid #aaaaaa;
            height: 70px;
            background: #ffffff;
        }

        #logo-container
        {
            width:80%;
            margin:0 auto;
            background: #ffffff;
        }
        #loggedUser
        {
            float: left;
            text-align: center;
            padding:25px;
            color: darkorange;
        }
        #loggedUser a
        {
            color: darkorange;

        }

        #search-box
        {
            float: left;
            width: 40%;
            padding: 15px;
            text-align: center;
        }

        #tbSearch
        {
            width: 65%;
        }

        #bSearch
        {
            width: 25%;
            position:relative;
            top: 2px;
        }

        #tbSearch #bSearch
        {
            height: 50px;
            font-size: 40px;
        }

        #basket-and-user
        {
            width:30%;
            height:70px;
            float:left;
        }

        #basket
        {
            width:50px;
            padding:10px;
            position:relative;
            float: left;
        }

        #itemsCounter
        {
            display:block;
            width:20px;
            height:20px;
            text-align:center;
            border-radius:10px;
            position: absolute;
            bottom:5px;
            right:5px;
        }


        #categories-fluid-container{
            border-bottom: 2px solid #aaaaaa;
            min-height: 35px;
            background: #ffffff;
        }

        #products-fluid-container{
            background: #edeff1;
        }

        #products
        {
            width: 80%;
            margin: 0 auto;
        }
        #categories{
            width:70%;
            margin: 0 auto;
            padding:5px;
            font-size: 15px;
        }


        #ddlAuthors, #ddlOrder
        {
            border: 1px solid darkorange;
            color: darkorange;
            position: relative;
        }

        #lAuthors, #lOrder
        {
            font-weight:700;
            color: darkorange;
        }
        #list, #order
        {
            width: 30%;
            padding-top: 8px;
        }

        #list, #order
        {
            float: left;
            margin: 0 1%;
        }

        .product
        {
            min-height: 200px;
            background-color: white;
            width:100%;
            padding:20px;
        }

        .product img
        {
            width:200px;
            float: left;
            margin: 5px;
        }

        .product span
        {
            display:block;
            margin: 5px;
        }

        #dlProducts
        {
            width: 100%;
        }

        #footer
        {
            height:30px;
        }

        #footer div
        {
            padding:30px;
            color: white;
            background-color:#222222;
            text-align:center;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="logo-fluid-container">
            <div id="logo-container">
                <div id="logo"><a href="Index.aspx">Shop for Business</a></div>
                <div id="search-box">
                    <asp:TextBox runat="server" ID="tbSearch" placeholder="czego szukasz?" Height="30px" Font-Size="Large" />
                    <asp:Button runat="server" ID="bSearch" Text="Wyszukaj" Height="36px" BackColor="DarkOrange" BorderWidth="0px" Font-Size="15pt" ForeColor="White" CssClass="auto-style1" Font-Names="'roboto', sans-serif" OnClick="bSearch_Click"/>
                </div>
                <div id="basket-and-user">
                    <div id="basket">
                        <asp:ImageButton OnClick="ibBasket_Click" ID="ibBasket" runat="server" ImageUrl="~/Content/Images/basket.png" Width="100%"/>
                        <asp:Label ID="itemsCounter" Text="0" BackColor="Red" runat="server" Visible="false"></asp:Label>
                    </div>
                    <div id="loggedUser"><%= LoggedUser != null ? "Witaj " + LoggedUser.Email.Split('@')[0]+"<br />" : "<a href='Login.aspx'>Zaloguj się!</a>" %>
                        <asp:LinkButton ID="lbLogout" runat="server" OnClick="lbLogout_Click" Visible="false">Wyloguj się!</asp:LinkButton>    
                    </div>
                </div>
                <div style="clear: both"></div>
            </div>
        </div>
        <div id="categories-fluid-container">
            <div id="categories">
                <div id="list"><asp:Label runat="server" ID="lAuthors">Autor:</asp:Label>
                <asp:DropDownList ID="ddlAuthors" runat="server" OnSelectedIndexChanged="ddlAuthors_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Selected="True">Wszyscy</asp:ListItem>
                </asp:DropDownList></div>
                <div id="order"><asp:Label runat="server" ID="lOrder">Sortuj:</asp:Label>
                <asp:DropDownList ID="ddlOrder" runat="server" OnSelectedIndexChanged="ddlAuthors_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Selected="True">Domyślnie</asp:ListItem>
                    <asp:ListItem>Cena rosnąco</asp:ListItem>
                    <asp:ListItem>Cena malejąco</asp:ListItem>
                    <asp:ListItem>Alfabetycznie</asp:ListItem>
                    <asp:ListItem>Odwrotnie do alfabetycznie</asp:ListItem>
                </asp:DropDownList></div>
                <div style="clear:both" ></div>
            </div>
        </div>
        <div id="products-fluid-container">
        <div id="products">
            <asp:DataList ID="dlProducts" runat="server">
                <ItemTemplate>  
                    <div class="product">
                        <asp:Image ID="imageProduct" runat="server" ImageUrl='<%# Eval("ImageUrl") %>'/>
                        <asp:Label ID="idInfo" runat="server" Text='<%# Eval("ID") %>' Visible="false"/>
                        <asp:Label runat="server" Font-Size="30px"><%# Eval("Name") %></asp:Label>
                        <asp:Label runat="server" Font-Size="35px"><%# String.Format("{0:0.00}", (float)Eval("Prize")) %> zł</asp:Label>
                        <asp:Label runat="server"><%# Eval("Author") %></asp:Label>
                        <asp:Label runat="server"><%# Eval("Description") %></asp:Label>
                        <asp:LinkButton OnClick="lbAdd_Click" ID='lbAdd'  runat="server">Dodaj do koszyka</asp:LinkButton>
                    </div>
                </ItemTemplate> 
            </asp:DataList>
        </div>
        </div>
        <div id="footer"><div>Shop For Business Sp. z o.o. &copy; 2019 Wszelkie prawa zastrzeżone</div></div>
    </form>
</body>
</html>
