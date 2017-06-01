<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Kit.Web.Ksystemset.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
        <tr>
            <td height="25" width="30%" align="right">
                Sid
                ：</td>
            <td height="25" width="*" align="left">
                <asp:Label id="lblSid" runat="server"></asp:Label>
            </td></tr>
        <tr>
            <td height="25" width="30%" align="right">
                Stype
                ：</td>
            <td height="25" width="*" align="left">
                <asp:Label id="lblStype" runat="server"></asp:Label>
            </td></tr>
        <tr>
            <td height="25" width="30%" align="right">
                Sname
                ：</td>
            <td height="25" width="*" align="left">
                <asp:Label id="lblSname" runat="server"></asp:Label>
            </td></tr>
        <tr>
            <td height="25" width="30%" align="right">
                Svalue
                ：</td>
            <td height="25" width="*" align="left">
                <asp:Label id="lblSvalue" runat="server"></asp:Label>
            </td></tr>
        <tr>
            <td height="25" width="30%" align="right">
                Skey1
                ：</td>
            <td height="25" width="*" align="left">
                <asp:Label id="lblSkey1" runat="server"></asp:Label>
            </td></tr>
        <tr>
            <td height="25" width="30%" align="right">
                Skey2
                ：</td>
            <td height="25" width="*" align="left">
                <asp:Label id="lblSkey2" runat="server"></asp:Label>
            </td></tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




