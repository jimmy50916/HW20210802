<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="SystemAdmin.Master" CodeBehind="UserDetail.aspx.cs" Inherits="TryAccountingNote20210730.SystemAdmin.UserDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <h3>會員管理</h3>
    <!--這裡放主要內容-->
    帳號:<asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
    <br />
    姓名:<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    <br />
    Email:<asp:TextBox ID="txtUserEmail" runat="server"></asp:TextBox>
    <br />
    等級:<asp:DropDownList ID="ddlUserLevel" runat="server">
        <asp:ListItem Value="0">管理員</asp:ListItem>
        <asp:ListItem Value="1">一般使用者</asp:ListItem>
    </asp:DropDownList>
    <br />
    建立時間: 
        <asp:Label ID="lblCreatedDate" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="btnSaveUserInfo" runat="server" Text="Save" OnClick="btnSaveUserInfo_Click" />
    &nbsp;
    <asp:Button ID="btnDeleteUserInfo" runat="server" Text="Delete" OnClick="btnDeleteUserInfo_Click" />
    <asp:Button ID="btnEditUserPassword" runat="server" Text="修改密碼" OnClick="btnEditUserPassword_Click" />
    <br />
    <asp:Literal ID="ltUserDetailMsg" runat="server"></asp:Literal>
</asp:Content>

