<%@ Page Title="UserList" Language="C#" AutoEventWireup="true" MasterPageFile="SystemAdmin.Master" CodeBehind="UserList.aspx.cs" Inherits="TryAccountingNote20210730.SystemAdmin.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <!--這裡放主要內容-->
    <h3>會員管理</h3>
    <asp:Button ID="btnCreate" runat="server" Text="Add Accounting" OnClick="btnCreate_Click" />
    <asp:GridView ID="gvAccountingList" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvAccountingList_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="帳號" DataField="Account" />
            <asp:BoundField HeaderText="姓名" DataField="Name" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:TemplateField HeaderText="等級">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblUserLevel"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="建立日期" DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="Act">
                <ItemTemplate>
                    <a href="/SystemAdmin/UserDetail.aspx?UID=<%# Eval("ID") %>">Edit</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
