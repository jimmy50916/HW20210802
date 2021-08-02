<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPassword.aspx.cs" Inherits="TryAccountingNote20210730.SystemAdmin.UserPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>流水帳管理系統</h1>
            <a href="Login.aspx">登入</a>
        </div>
        
        <%--<asp:PlaceHolder runat="server" ID="plcChangePWD" Visible="false">--%>
            Password:
            <asp:TextBox ID="txtPWD" runat="server"  TextMode="Password"></asp:TextBox>
            <br />
            NewPassword:
            <asp:TextBox ID="txtNewPWD" runat="server"  TextMode="Password" ></asp:TextBox>
            <br />
            Check your Password
            <asp:TextBox ID="txtCheckPWD" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="btnChangePWD" runat="server" Text="Change password" OnClick="ChangePWD_Click"/><br />
            <asp:Literal ID="ltlMsgPWD" runat="server"></asp:Literal>
       <%-- </asp:PlaceHolder>--%>

    </form>
</body>
</html>
