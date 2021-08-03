<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="SystemAdmin.Master" CodeBehind="AccountingList.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <!--這裡放主要內容-->
    <asp:Button ID="btnCreate" runat="server" Text="Add Accounting" OnClick="btnCreate_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
    <asp:GridView ID="gvAccountingList" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvAccountingList_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="標題" DataField="Caption" />
            <asp:BoundField HeaderText="金額" DataField="Amount" />
            <asp:TemplateField HeaderText="In/Out">
                <ItemTemplate>
                    <%--<%# ((int)Eval("ActType") == 0) ? "支出" : "收入" %>--%>
                    <%--<asp:Literal runat="server" ID="ltActType"></asp:Literal>--%>
                    <asp:Label runat="server" ID="lblActType"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="建立日期" DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="Act">
                <ItemTemplate>
                    <a href="/SystemAdmin/AccountingDetail.aspx?ID=<%# Eval("ID") %>">Edit</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
        <p style="color: red; background-color: cornflowerblue">
            No data in your Accounting Note.
                       
        </p>
    </asp:PlaceHolder>
</asp:Content>

