﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryAccountingNote20210730.SystemAdmin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: #CCFFFF">
            <h1>流水帳管理系統&nbsp;
            <a href="Login.aspx" style="font-size: 20px">登入系統</a></h1>
        </div>
        <table>
            <tr>
                <td>
                    <ul>
                        <li>
                            <p>初次記帳時間</p>
                            <asp:TextBox ID="txtFirstaccount" runat="server"></asp:TextBox>
                        </li>
                        <li>
                            <p>最後記帳時間</p>
                            <asp:TextBox ID="txtLastaccount" runat="server"></asp:TextBox>
                        </li>
                        <li>
                            <p>計帳數量</p>
                            <asp:TextBox ID="txtAccountquantity" runat="server"></asp:TextBox>
                        </li>
                        <li>
                            <p>會員數</p>
                            <asp:TextBox ID="txtUserquantity" runat="server"></asp:TextBox>
                        </li>
                    </ul>

                </td>
            </tr>
            <tr>
            </tr>
        </table>
    </form>
</body>
</html>
