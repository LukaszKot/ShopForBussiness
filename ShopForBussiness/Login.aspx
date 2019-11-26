<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShopForBussiness.Index" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <style type="text/css">
        body
        {
            margin: 0;
            padding: 0;
        }
        .auto-style1 {
            width: 100%;
            float: left;
        }
        td
        {
            margin-left: auto;
            margin-right: auto;
            text-align: center;
        }
        .auto-style4 {
            height: 23px;
        }

        .login, .registration
        {
            border: 3px solid #4cff00;
            border-radius: 20px;
            text-align: left;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style4" colspan="2">
                <asp:Label ID="lTitle" runat="server" Text="Shop For Business" Font-Names="Lucida Handwriting" Font-Size="70pt"></asp:Label>
            </td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style4 login">
                <asp:Label ID="lLoginTitle" runat="server" Text="Logowanie" Font-Names="Nirmala UI" Font-Size="35pt"></asp:Label><br />
                <asp:Label ID="lLoginEmail" runat="server" Text="Email" Font-Names="Nirmala UI" Height="30px"></asp:Label>&nbsp;
                <asp:TextBox ID="tbLoginEmail" runat="server" Width="149px" Height="21px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Wymagany adres email!" ControlToValidate="tbLoginEmail" Text="" ValidationGroup="vgLogin"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Niepoprawny adres email!"  ControlToValidate="tbLoginEmail" Text="" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vgLogin"></asp:RegularExpressionValidator><br />
                <asp:Label ID="lLoginPassword" runat="server" Text="Hasło" Font-Names="Nirmala UI" Height="30px"></asp:Label>&nbsp;
                <asp:TextBox ID="tbLoginPassword" runat="server" Width="149px" Height="21px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Wymagane hasło!" ControlToValidate="tbLoginPassword" ValidationGroup="vgLogin"></asp:RequiredFieldValidator><br />
                <asp:Button ID="bLogin" runat="server" Text="Zaloguj się!" Width="234px" ValidationGroup="vgLogin" OnClick="bLogin_Click" /><br />
                <asp:ValidationSummary ID="vsLogin" runat="server" BorderStyle="None" DisplayMode="List" ValidationGroup="vgLogin" />
            </td>
            <td class="auto-style4 registration">
                <asp:Label ID="lRegistrationTitle" runat="server" Text="Rejestracja" Font-Names="Nirmala UI" Font-Size="35pt"></asp:Label><br />
                <asp:Label ID="lRegistrationEmail" runat="server" Text="Email" Font-Names="Nirmala UI" Height="30px" ></asp:Label>&nbsp;
                <asp:TextBox ID="tbRegistrationEmail" runat="server" Width="177px" Height="21px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Wymagany adres email!" ControlToValidate="tbRegistrationEmail" Text="" ValidationGroup="vgRegister"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Niepoprawny adres email!"  ControlToValidate="tbRegistrationEmail" Text="" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vgRegister"></asp:RegularExpressionValidator><br />
                <asp:Label ID="lRegistrationPassword" runat="server" Text="Hasło" Font-Names="Nirmala UI" Height="30px"></asp:Label>&nbsp;
                <asp:TextBox ID="tbRegistrationPassword" runat="server" Width="177px" Height="21px" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Wymagane hasło!" ControlToValidate="tbRegistrationPassword" Text="" ValidationGroup="vgRegister"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Podane hasło nie ma jednej małej litery, jednej dużej oraz liczby!"  ControlToValidate="tbRegistrationPassword" Text="" ValidationExpression="(?=.*[a-z])(?=.*[0-9])(?=.*[A-Z])([a-zA-Z0-9]+)" ValidationGroup="vgRegister"></asp:RegularExpressionValidator><br />
                <asp:Label ID="lRegistrationRetypePassword" runat="server" Text="Powtórz hasło " Font-Names="Nirmala UI" Height="30px"></asp:Label>&nbsp;
                <asp:TextBox ID="tbRegistrationRetypePassword" runat="server" Width="177px" Height="21px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Musisz podać hasło jeszcze raz!" ControlToValidate="tbRegistrationRetypePassword" Text="" ValidationGroup="vgRegister"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbRegistrationPassword" ControlToValidate="tbRegistrationRetypePassword" ErrorMessage="Hasła muszą być identyczne!" ValidationGroup="vgRegister"></asp:CompareValidator>
                <br />
                <asp:CheckBox runat="server" ID="cRegulation" Text="Akceptuję regulamin sklepu Shop For Business"></asp:CheckBox><br />
                <asp:Button ID="bRegister" runat="server" Text="Zarejestruj się!" Width="234px" ValidationGroup="vgRegister" OnClick="bRegister_Click" /><br />
                <asp:ValidationSummary ID="vsRegister" runat="server" BorderStyle="None" DisplayMode="List" ValidationGroup="vgRegister" />
            </td>
            <td class="auto-style4">&nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
