<%@ Page Title="UserPasswordPage" Language="C#" AutoEventWireup="true" MasterPageFile="SystemAdmin.Master" CodeBehind="UserPassword.aspx.cs" Inherits="TryAccountingNote20210730.SystemAdmin.UserPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div class="div1">
        <h3>會員管理</h3>
        舊密碼:&emsp;&emsp;
    <asp:TextBox ID="txtPWD" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        檢查舊密碼:
    <asp:TextBox ID="txtCheckPWD" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        新密碼:&emsp;&emsp;
    <asp:TextBox ID="txtNewPWD" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        檢查新密碼:
    <asp:TextBox ID="txtChecknewPWD" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Button ID="btnChangePWD" runat="server" Text="送出" OnClick="ChangePWD_Click" /><br />
        <asp:Literal ID="ltlMsgPWD" runat="server"></asp:Literal>
    </div>
</asp:Content>
