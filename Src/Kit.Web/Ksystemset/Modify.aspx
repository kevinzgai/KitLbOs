<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Kit.Web.Ksystemset.Modify" Title="修改页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
        <tr>
            <td height="25" width="30%" align="right">
                Sid
                ：</td>
            <td height="25" width="*" align="left">
                <asp:label id="lblSid" runat="server"></asp:label>
            </td></tr>
        <tr>
            <td height="25" width="30%" align="right">
                Stype
                ：</td>
            <td height="25" width="*" align="left">
                <asp:TextBox id="txtStype" runat="server" Width="200px"></asp:TextBox>
            </td></tr>
        <tr>
            <td height="25" width="30%" align="right">
                Sname
                ：</td>
            <td height="25" width="*" align="left">
                <asp:TextBox id="txtSname" runat="server" Width="200px"></asp:TextBox>
            </td></tr>
        <tr>
            <td height="25" width="30%" align="right">
                Svalue
                ：</td>
            <td height="25" width="*" align="left">
                <asp:TextBox id="txtSvalue" runat="server" Width="200px"></asp:TextBox>
            </td></tr>
        <tr>
            <td height="25" width="30%" align="right">
                Skey1
                ：</td>
            <td height="25" width="*" align="left">
                <asp:TextBox id="txtSkey1" runat="server" Width="200px"></asp:TextBox>
            </td></tr>
        <tr>
            <td height="25" width="30%" align="right">
                Skey2
                ：</td>
            <td height="25" width="*" align="left">
                <asp:TextBox id="txtSkey2" runat="server" Width="200px"></asp:TextBox>
            </td></tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

