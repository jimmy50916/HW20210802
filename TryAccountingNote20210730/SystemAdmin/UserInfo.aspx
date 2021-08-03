<%@ Page Title="UserInfoPage" Language="C#" AutoEventWireup="true" MasterPageFile="SystemAdmin.Master" CodeBehind="UserInfo.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <h3>使用者資訊</h3>
    <!--這裡放主要內容-->
    <table>
        <tr>
            <th>Account</th>
            <td><asp:Literal runat="server" ID="ltAccount"></asp:Literal></td>
        </tr>
        <tr>
            <th>Name</th>
            <td><asp:Literal runat="server" ID="ltName"></asp:Literal></td>
        </tr>
        <tr>
            <th>Email</th>
            <td><asp:Literal runat="server" ID="ltEmail"></asp:Literal></td>
        </tr>
    </table>
    <asp:Button runat="server" ID="btnLogout" Text="Logout" OnClick="btnLogout_Click" />
</asp:Content>

