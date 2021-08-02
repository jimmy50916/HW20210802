<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="TryAccountingNote20210730.SystemAdmin.UserDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td colspan="2">
                    <h1>流水帳管理系統 - 後台</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="UserInfo.aspx">使用者資訊</a> <br />
                    <a href="AccountingList.aspx"> 流水帳管理 </a> <br />
                    <a href="UserList.aspx"> 會員管理 </a>
                </td>
                <td>
                    <h3>會員管理</h3>
                    <!--這裡放主要內容-->
                    帳號: 
                        <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
                    <br />
                    姓名: 
                        <asp:TextBox ID="txtUserName" runat="server" ></asp:TextBox>
                    <br />
                    Email: 
                        <asp:TextBox ID="txtUserEmail" runat="server"></asp:TextBox>
                    <br />
                    等級:
                        <asp:DropDownList ID="ddlUserLevel" runat="server">
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
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
