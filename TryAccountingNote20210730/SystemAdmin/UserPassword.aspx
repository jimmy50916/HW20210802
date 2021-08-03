<%@ Page  Language="C#" AutoEventWireup="true" MasterPageFile="SystemAdmin.Master" CodeBehind="UserPassword.aspx.cs" Inherits="TryAccountingNote20210730.SystemAdmin.UserPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    Password:
    <asp:TextBox ID="txtPWD" runat="server"  TextMode="Password"></asp:TextBox>
    <br />
    Check Password:
    <asp:TextBox ID="txtCheckPWD" runat="server"  TextMode="Password"></asp:TextBox>
    <br />
    NewPassword:
    <asp:TextBox ID="txtNewPWD" runat="server"  TextMode="Password" ></asp:TextBox>
    <br />
    Check your New Password
    <asp:TextBox ID="txtChecknewPWD" runat="server" TextMode="Password"></asp:TextBox><br />
    <asp:Button ID="btnChangePWD" runat="server" Text="Change password" OnClick="ChangePWD_Click"/><br />
    <asp:Literal ID="ltlMsgPWD" runat="server"></asp:Literal>
</asp:Content>
