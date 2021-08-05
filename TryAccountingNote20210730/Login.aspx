<%@ Page Title="登入頁面" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AccountingNote.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body style="background-color:paleturquoise">
    <form id="form1" runat="server">
        <div style="text-align: center">
            <h1 style="background-color: #CCFFFF">流水帳管理系統</h1>
        </div>
        <div align="center">
            <asp:PlaceHolder runat="server" ID="plcLogin" Visible="false">
                Account:
            <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
                Password:
            <asp:TextBox ID="txtPWD" runat="server" TextMode="Password"></asp:TextBox><br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /><br />
                <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
